using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.ServiceLayer.Storage;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet;
using MoneyPot_NetApiExt.Generated.Model.primitive_types;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using MoneyPot_NetApiExt.Generated.Storage;
using Shared_MoneyPot;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using static MoneyPot_BlazorFront.Repository.IMoneyPotRepository;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class MoneyPotRepositoryDirectAccess : IMoneyPotRepository
    {
        private readonly ISubstrateService _substrateService;
        private readonly IAccountService _accountService;
        private readonly IList<MoneyPotDto> _moneyPots = new List<MoneyPotDto>();

        public MoneyPotRepositoryDirectAccess(ISubstrateService substrateService, IAccountService accountService) //, IStorageDataProvider storageDataProvider
        {
            _substrateService = substrateService;
            _accountService = accountService;
            //_storageDataProvider = storageDataProvider;
        }

        public async Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
        {
            // Subscribe when a money pot is created
            Action<string, StorageChangeSet> moneyPotCountChangeset = async (subscriptionId, storageChangeSet) =>
            {
                var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var nbPots = new U32();
                nbPots.Create(hexString);

                for (var i = 1; i <= nbPots.Value; i++)
                {
                    var idx = new U32();
                    idx.Create((uint)i);

                    H256 moneyPotHash = await _substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);
                    var moneyPotHashHex = Utils.Bytes2HexString(moneyPotHash.Value.Bytes);

                    // Subscribe when a money pot change
                    var moneyPotsSubstrateParams = MoneyPotStorage.MoneyPotsParams(moneyPotHash);
                    await _substrateService.Client.SubscribeStorageKeyAsync(moneyPotsSubstrateParams, async (subscriptionId, storageChangeSet) =>
                    {
                        var hexString = SubstrateHelper.getChangesetData(storageChangeSet);
                        if (string.IsNullOrEmpty(hexString)) return;

                        var moneyPotVanilla = new MoneyPot();
                        moneyPotVanilla.Create(hexString);

                        MoneyPotDto moneyPotElem = new MoneyPotDto();
                        moneyPotElem.Hash = moneyPotHashHex;
                        moneyPotElem.Creator = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Owner);
                        moneyPotElem.Receiver = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Receiver);
                        moneyPotElem.IsFinished = !moneyPotVanilla.IsActive.Value;
                        if (moneyPotVanilla.EndTime.Value.Value == EndType.AmountReached)
                        {
                            moneyPotElem.TypeEnd = TypeEndDto.AmountLimit;

                            // Get target amount
                            var amountType = (BaseTuple<EnumAmountType, U128>)moneyPotVanilla.EndTime.Value.Value2;
                            // Reminder : amountType.Value[0] => token type
                            
                            moneyPotElem.AmountTarget = (double)((U128)amountType.Value[1]).Value;
                        }
                        else
                        {
                            moneyPotElem.TypeEnd = TypeEndDto.BlockLimit;
                        }

                        _moneyPots.AddOrUpdate(moneyPotElem);
                        moneyPotCallback(moneyPotElem);
                    }, CancellationToken.None);

                    // Subscribe when a contribution is done
                    var moneyPotsContributionParams = MoneyPotStorage.MoneyPotContributionParams(moneyPotHash);
                    await _substrateService.Client.SubscribeStorageKeyAsync(moneyPotsContributionParams, async (subscriptionId, storageChangeSet) =>
                    {
                        var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                        if (string.IsNullOrEmpty(hexString)) return;

                        var contributions = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5();
                        contributions.Create(hexString);

                        var currentMoneyPot = _moneyPots.FirstOrDefault(x => x.Hash == moneyPotHashHex);
                        if (currentMoneyPot == null) return;

                        if (contributions.Value != null)
                        {
                            currentMoneyPot.Contributors = new List<ContributorDto>();
                            foreach (BaseTuple<AccountId32, U128> contrib in contributions.Value.Value)
                            {
                                currentMoneyPot.Contributors.Add(new ContributorDto()
                                {
                                    Contributor = SubstrateHelper.BuildAccountDto((AccountId32)contrib.Value[0]),
                                    Amount = (double)((U128)contrib.Value[1]).Value
                                });
                            }
                        }

                        _moneyPots.AddOrUpdate(currentMoneyPot);
                        moneyPotCallback(currentMoneyPot);
                    }, CancellationToken.None);
                }
            };

            var moneyPotsParams = MoneyPotStorage.MoneyPotsCountParams();
            await _substrateService.Client.SubscribeStorageKeyAsync(moneyPotsParams, moneyPotCountChangeset, CancellationToken.None);
        }

        public async Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<ExtrinsicStatusDto> createCallback)
        {
            await submitExtrinsicAsync(
                MoneyPotCalls.CreateWithLimitAmount(
                    SubstrateHelper.BuildAccountId32(receiver),
                    SubstrateHelper.ToPrimitive<double, U128, BigInteger>(amount, (amount) => new BigInteger(amount).ToByteArray())
                ), createCallback);
        }

        public async Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<ExtrinsicStatusDto> contributeCallback)
        {
            var hash = new H256();
            hash.Create(moneyPot.Hash);

            await submitExtrinsicAsync(
                    MoneyPotCalls.AddFundsToPot(hash, 
                    SubstrateHelper.ToPrimitive<double, U128, BigInteger>(amount, (amount) => new BigInteger(amount).ToByteArray())
                ), contributeCallback);
        }

        /// <summary>
        /// Submit an extrinsic and wait for status callback
        /// </summary>
        /// <param name="method"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        private async Task submitExtrinsicAsync(Method method, Action<ExtrinsicStatusDto> callback)
        {
            try
            {
                await _substrateService.Client.Author.SubmitAndWatchExtrinsicAsync((string s, ExtrinsicStatus status) =>
                {
                    if (status.ExtrinsicState == ExtrinsicState.Ready)
                        callback(ExtrinsicStatusDto.Waiting);

                    else if (status.InBlock != null)
                        callback(ExtrinsicStatusDto.InBlock);

                    else if (status.Finalized != null)
                        callback(ExtrinsicStatusDto.Finalized);

                    else
                        callback(ExtrinsicStatusDto.Error);
                }, method, SubstrateHelper.BuildAccount(_accountService.ConnectedAccount), ChargeTransactionPayment.Default(), 128, CancellationToken.None);
            } catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                callback(ExtrinsicStatusDto.Error);
            }
            
        }
    }
}


//public async Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
//{
//    Action<string, Func<string, MoneyPotDto>> SubscribeAndWatchAsync = async (string methodParam, Func<string, MoneyPotDto> action) =>
//    {
//        await _substrateService.Client.SubscribeStorageKeyAsync(methodParam, async (subscriptionId, storageChangeSet) =>
//        {
//            var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

//            // No data
//            if (string.IsNullOrEmpty(hexString)) return;

//            var moneyPot = action(hexString);

//            if (moneyPot != null)
//            {
//                _moneyPots.AddOrUpdate(moneyPot);
//                moneyPotCallback(moneyPot);
//            }
//        }, CancellationToken.None);
//    };

//    // Subscribe when a money pot is added
//    await SubscribeAndWatchAsync(MoneyPotStorage.MoneyPotsCountParams(), async (string hexString) =>
//    {
//        var nbPots = new U32();
//        nbPots.Create(hexString);

//        for (var i = 1; i <= nbPots.Value; i++)
//        {
//            var idx = new U32();
//            idx.Create((uint)i);

//            H256 moneyPotHash = await _substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);
//            var moneyPotHashHex = Utils.Bytes2HexString(moneyPotHash.Value.Bytes);

//            // Subscribe when a money pot change
//            await SubscribeAndWatchAsync(MoneyPotStorage.MoneyPotsParams(moneyPotHash), async (string hexString) => {
//                var moneyPotVanilla = new MoneyPot();
//                moneyPotVanilla.Create(hexString);

//                MoneyPotDto moneyPotElem = new MoneyPotDto();
//                moneyPotElem.Hash = moneyPotHashHex;
//                moneyPotElem.Creator = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Owner);
//                moneyPotElem.Receiver = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Receiver);
//                moneyPotElem.IsFinished = !moneyPotVanilla.IsActive.Value;
//                if (moneyPotVanilla.EndTime.Value.Value == EndType.AmountReached)
//                {
//                    moneyPotElem.TypeEnd = TypeEndDto.AmountLimit;

//                    // Get target amount
//                    var amountType = (BaseTuple<EnumAmountType, U128>)moneyPotVanilla.EndTime.Value.Value2;
//                    // Reminder : amountType.Value[0] => token type

//                    moneyPotElem.AmountTarget = (double)((U128)amountType.Value[1]).Value;
//                }
//                else
//                {
//                    moneyPotElem.TypeEnd = TypeEndDto.BlockLimit;
//                }

//                return moneyPotElem;
//            });

//            // Subscribe when a contribution is done
//            await SubscribeAndWatchAsync(MoneyPotStorage.MoneyPotContributionParams(moneyPotHash), async (string hexString) =>
//            {
//                var contributions = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5();
//                contributions.Create(hexString);

//                var currentMoneyPot = _moneyPots.FirstOrDefault(x => x.Hash == moneyPotHashHex);
//                if (currentMoneyPot == null) return null;

//                if (contributions.Value != null)
//                {
//                    currentMoneyPot.Contributors = new List<ContributorDto>();
//                    foreach (BaseTuple<AccountId32, U128> contrib in contributions.Value.Value)
//                    {
//                        currentMoneyPot.Contributors.Add(new ContributorDto()
//                        {
//                            Contributor = SubstrateHelper.BuildAccountDto((AccountId32)contrib.Value[0]),
//                            Amount = (double)((U128)contrib.Value[1]).Value
//                        });
//                    }
//                }

//                return currentMoneyPot;
//            });
//        }

//        return null;
//    });
//}        
