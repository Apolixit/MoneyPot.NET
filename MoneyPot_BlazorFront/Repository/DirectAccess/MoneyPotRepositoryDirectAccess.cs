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
        private ISubstrateService substrateService;
        private IAccountService accountService;

        //private IStorageDataProvider storageDataProvider;
        private IList<MoneyPotDto> moneyPots = new List<MoneyPotDto>();

        public MoneyPotRepositoryDirectAccess(ISubstrateService substrateService, IAccountService accountService) //, IStorageDataProvider storageDataProvider
        {
            this.substrateService = substrateService;
            this.accountService = accountService;
            //this.storageDataProvider = storageDataProvider;
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

                    H256 moneyPotHash = await substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);
                    var moneyPotHashHex = Utils.Bytes2HexString(moneyPotHash.Value.Bytes);

                    // Subscribe when a money pot change
                    var moneyPotsSubstrateParams = MoneyPotStorage.MoneyPotsParams(moneyPotHash);
                    await substrateService.Client.SubscribeStorageKeyAsync(moneyPotsSubstrateParams, async (subscriptionId, storageChangeSet) =>
                    {
                        var hexString = SubstrateHelper.getChangesetData(storageChangeSet);
                        if (String.IsNullOrEmpty(hexString)) return;

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
                        }
                        else
                        {
                            moneyPotElem.TypeEnd = TypeEndDto.BlockLimit;
                        }

                        moneyPots.AddOrUpdate(moneyPotElem);

                        moneyPotCallback(moneyPotElem);
                    }, CancellationToken.None);

                    // Subscribe when a contribution is done
                    var moneyPotsContributionParams = MoneyPotStorage.MoneyPotContributionParams(moneyPotHash);
                    await substrateService.Client.SubscribeStorageKeyAsync(moneyPotsContributionParams, async (subscriptionId, storageChangeSet) =>
                    {
                        var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                        if (String.IsNullOrEmpty(hexString)) return;

                        var contributions = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5();
                        contributions.Create(hexString);

                        var currentMoneyPot = moneyPots.FirstOrDefault(x => x.Hash == moneyPotHashHex);
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

                        moneyPotCallback(currentMoneyPot);
                    }, CancellationToken.None);
                }
            };

            var moneyPotsParams = MoneyPotStorage.MoneyPotsCountParams();
            await substrateService.Client.SubscribeStorageKeyAsync(moneyPotsParams, moneyPotCountChangeset, CancellationToken.None);
        }

        public async Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<ExtrinsicStatusDto> createCallback)
        {
            await SubmitExtrinsicAsync(MoneyPotCalls.CreateWithLimitAmount(SubstrateHelper.BuildAccountId32(receiver), fromDouble(amount)), createCallback);
        }

        public async Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<ExtrinsicStatusDto> contributeCallback)
        {
            var hash = new H256();
            hash.Create(moneyPot.Hash);

            await SubmitExtrinsicAsync(MoneyPotCalls.AddFundsToPot(hash, fromDouble(amount)), contributeCallback);
        }

        public async Task SubmitExtrinsicAsync(Method method, Action<ExtrinsicStatusDto> callback)
        {
            await substrateService.Client.Author.SubmitAndWatchExtrinsicAsync((string s, ExtrinsicStatus status) =>
            {
                if (status.ExtrinsicState == ExtrinsicState.Ready)
                    callback(ExtrinsicStatusDto.Waiting);

                else if (status.InBlock != null)
                    callback(ExtrinsicStatusDto.InBlock);
                
                else if(status.Finalized != null)
                    callback(ExtrinsicStatusDto.Finalized);

                else
                    callback(ExtrinsicStatusDto.Error);
            }, method, SubstrateHelper.BuildAccount(accountService.ConnectedAccount), ChargeTransactionPayment.Default(), 128, CancellationToken.None);
        }

        private U128 fromDouble(double amount)
        {
            var u128Amount = new U128();
            u128Amount.Create(new BigInteger(amount));
            return u128Amount;
        }
    }
}
