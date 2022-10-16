using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet;
using MoneyPot_NetApiExt.Generated.Model.primitive_types;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using MoneyPot_NetApiExt.Generated.Storage;
using Shared_MoneyPot;
using System.Diagnostics;
using System.Linq;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class MoneyPotRepositoryDirectAccess : IMoneyPotRepository
    {
        private ISubstrateService substrateService;
        private IList<MoneyPotDto> moneyPots = new List<MoneyPotDto>();

        public MoneyPotRepositoryDirectAccess(ISubstrateService substrateService)
        {
            this.substrateService = substrateService;
        }

        public Task<IEnumerable<MoneyPotDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD101:Avoid unsupported async delegates", Justification = "<Pending>")]
        public async Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
        {
            // Subscribe when a money pot is created
            Action<string, StorageChangeSet> moneyPotCountChangeset = async (subscriptionId, storageChangeSet) =>
            {
                var hexString = getChangesetData(storageChangeSet);

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var nbPots = new U32();
                nbPots.Create(hexString);

                for (var i = 1; i <= nbPots.Value; i++)
                {
                    var idx = new U32();
                    idx.Create((uint)i);

                    H256 moneyPotHash = await substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);

                    // Subscribe when a money pot change
                    var moneyPotsSubstrateParams = MoneyPotStorage.MoneyPotsParams(moneyPotHash);
                    await substrateService.Client.SubscribeStorageKeyAsync(moneyPotsSubstrateParams, async (subscriptionId, storageChangeSet) =>
                    {
                        var hexString = getChangesetData(storageChangeSet);
                        if (String.IsNullOrEmpty(hexString)) return;

                        var moneyPotVanilla = new MoneyPot();
                        moneyPotVanilla.Create(hexString);

                        MoneyPotDto moneyPotElem = new MoneyPotDto();
                        moneyPotElem.Hash = moneyPotHash.Value.ToString();
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
                        var hexString = getChangesetData(storageChangeSet);

                        if (String.IsNullOrEmpty(hexString)) return;

                        var contributions = new MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5();
                        contributions.Create(hexString);

                        var currentMoneyPot = moneyPots.FirstOrDefault(x => x.Hash == moneyPotHash.Value.ToString());
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

        private string getChangesetData(StorageChangeSet storageChangeSet)
        {
            if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
            {
                throw new Exception("Couldn't update account information. Please check 'CallBackAccountChange'");
            }


            var hexString = storageChangeSet.Changes[0][1];

            //if (string.IsNullOrEmpty(hexString))
            //{
            //    throw new Exception("Unable to retrieve data");
            //}

            return hexString;
        }
    }
}
