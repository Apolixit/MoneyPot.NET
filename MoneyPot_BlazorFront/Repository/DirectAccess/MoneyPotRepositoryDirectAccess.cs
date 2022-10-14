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

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class MoneyPotRepositoryDirectAccess : IMoneyPotRepository
    {
        //private List<MoneyPotDto> moneyPotsCallback = new List<MoneyPotDto>();
        private ISubstrateService substrateService;
        public MoneyPotRepositoryDirectAccess(ISubstrateService substrateService)
        {
            this.substrateService = substrateService;
        }

        public Task<IEnumerable<MoneyPotDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD101:Avoid unsupported async delegates", Justification = "<Pending>")]
        public async Task SubscribeMoneyPotsAsync(Action<IEnumerable<MoneyPotDto>> moneyPotCallback)
        {
            Action<string, StorageChangeSet> action = async (subscriptionId, storageChangeSet) =>
            {
                if (storageChangeSet.Changes == null
                        || storageChangeSet.Changes.Length == 0
                        || storageChangeSet.Changes[0].Length < 2)
                {
                    Debug.WriteLine("Couldn't update account information. Please check 'CallBackAccountChange'");
                    return;
                }


                var hexString = storageChangeSet.Changes[0][1];

                if (string.IsNullOrEmpty(hexString))
                {
                    return;
                }

                List<MoneyPotDto> moneyPots = new List<MoneyPotDto>();

                var nbPots = new U32(); //await substrateService.Client.MoneyPotStorage.MoneyPotsCount(CancellationToken.None);
                nbPots.Create(hexString);

                for (var i = 1; i <= nbPots.Value; i++)
                {
                    var idx = new U32();
                    idx.Create((uint)i);

                    H256 moneyPotHash = await substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);
                    MoneyPot moneyPotVanilla = await substrateService.Client.MoneyPotStorage.MoneyPots(moneyPotHash, CancellationToken.None);
                    var contributions = await substrateService.Client.MoneyPotStorage.MoneyPotContribution(moneyPotHash, CancellationToken.None);

                    MoneyPotDto moneyPot = new MoneyPotDto();
                    moneyPot.Creator = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Owner);
                    moneyPot.Receiver = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Receiver);
                    moneyPot.IsFinished = !moneyPotVanilla.IsActive.Value;
                    if (moneyPotVanilla.EndTime.Value.Value == EndType.AmountReached)
                    {
                        moneyPot.TypeEnd = TypeEndDto.AmountLimit;
                    }
                    else
                    {
                        moneyPot.TypeEnd = TypeEndDto.BlockLimit;
                    }

                    if(contributions.Value != null)
                    {
                        moneyPot.Contributors = new List<ContributorDto>();
                        foreach (BaseTuple<AccountId32, U128> contrib in contributions.Value.Value)
                        {
                            moneyPot.Contributors.Add(new ContributorDto()
                            {
                                Contributor = SubstrateHelper.BuildAccountDto((AccountId32)contrib.Value[0]),
                                Amount = (double)((U128)contrib.Value[1]).Value
                            });
                            //var c1 = Utils.GetAddressFrom(((AccountId32)contrib.Value[0]).Value.Bytes);
                            //var c2 = ((U128)contrib.Value[1]).Value;
                        }
                    }
                    moneyPots.Add(moneyPot);
                }

                moneyPotCallback(moneyPots);
            };

            var moneyPotsParams = MoneyPotStorage.MoneyPotsCountParams();
            await substrateService.Client.SubscribeStorageKeyAsync(moneyPotsParams, action, CancellationToken.None);

        }

        //private async void subscribePotsAsync(string subscriptionId, StorageChangeSet storageChangeSet)
        //{
        //    if (storageChangeSet.Changes == null
        //            || storageChangeSet.Changes.Length == 0
        //            || storageChangeSet.Changes[0].Length < 2)
        //    {
        //        Debug.WriteLine("Couldn't update account information. Please check 'CallBackAccountChange'");
        //        return;
        //    }


        //    var hexString = storageChangeSet.Changes[0][1];

        //    if (string.IsNullOrEmpty(hexString))
        //    {
        //        return;
        //    }

        //    //List<MoneyPotDto> moneyPots = new List<MoneyPotDto>();

        //    var nbPots = new U32(); //await substrateService.Client.MoneyPotStorage.MoneyPotsCount(CancellationToken.None);
        //    nbPots.Create(hexString);

        //    for (var i = 1; i <= nbPots.Value; i++)
        //    {
        //        var idx = new U32();
        //        idx.Create((uint)i);

        //        H256 moneyPotHash = await substrateService.Client.MoneyPotStorage.MoneyPotsHash(idx, CancellationToken.None);
        //        MoneyPot moneyPotVanilla = await substrateService.Client.MoneyPotStorage.MoneyPots(moneyPotHash, CancellationToken.None);

        //        MoneyPotDto moneyPot = new MoneyPotDto();
        //        moneyPot.Creator = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Owner);
        //        moneyPot.Receiver = SubstrateHelper.BuildAccountDto(moneyPotVanilla.Receiver);
        //        moneyPot.IsFinished = !moneyPotVanilla.IsActive.Value;
        //        if (moneyPotVanilla.EndTime.Value.Value == EndType.AmountReached)
        //        {
        //            moneyPot.TypeEnd = TypeEndDto.AmountLimit;
        //        }
        //        else
        //        {
        //            moneyPot.TypeEnd = TypeEndDto.BlockLimit;
        //        }

        //        moneyPotsCallback.Add(moneyPot);
        //    }

        //    //var palletMoneyPot = new MoneyPot();
        //    //palletMoneyPot.Create(Utils.HexToByteArray(hexString));
        //    //var owner = Utils.GetAddressFrom(palletMoneyPot.Owner.Value.Bytes);
        //    //var receiver = Utils.GetAddressFrom(palletMoneyPot.Receiver.Value.Bytes);
        //    //var isActive = palletMoneyPot.IsActive.Value;
        //    //var visibility = palletMoneyPot.Visibility.Value;
        //    //var endTime = palletMoneyPot.EndTime.Value;
        //    //if (endTime.Value == EndType.AmountReached)
        //    //{
        //    //    //var xx = endTime.Value2;
        //    //    var y = (Ajuna.NetApi.Model.Types.Base.BaseTuple<EnumAmountType, U128>)endTime.Value2;
        //    //    //var xxx = endTime.Value2.Encode();
        //    //    //var y = new Ajuna.NetApi.Model.Types.Base.BaseTuple<EnumAmountType, U128>();
        //    //    //y.Create(xxx);
        //    //    AmountType typeAmount = ((EnumAmountType)y.Value[0]).Value;
        //    //    int montantAmount = (int)((U128)y.Value[1]).Value;
        //    //}
        //}
    }
}
