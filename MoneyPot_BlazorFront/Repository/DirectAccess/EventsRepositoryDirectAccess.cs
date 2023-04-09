using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using MoneyPot_NetApiExt.Generated.Model.frame_system;
using MoneyPot_NetApiExt.Generated.Model.node_template_runtime;
using MoneyPot_NetApiExt.Generated.Storage;
using MoneyPot_Shared;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class EventsRepositoryDirectAccess : IEventsRepository
    {
        private readonly ISubstrateService _substrateService;
        private readonly IBlockRepository _blockRepository;

        private readonly IList<EventDto> events = new List<EventDto>();

        public EventsRepositoryDirectAccess(ISubstrateService substrateService, IBlockRepository blockRepository)
        {
            _substrateService = substrateService;
            _blockRepository = blockRepository;
        }

        public async Task SubscribeNewEventAsync(Action<EventDto> eventCallback)
        {

            await _substrateService.Client.SubscribeStorageKeyAsync(SystemStorage.EventsParams(), async (string subscriptionId, StorageChangeSet storageChangeSet) => {
                var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var eventsReceived = new BaseVec<EventRecord>();
                eventsReceived.Create(hexString);

                foreach (EventRecord eventReceived in eventsReceived.Value)
                {
                    var eventCore = eventReceived.Event;
                    var secondaryEvent = string.Empty;

                    switch (eventCore.Value)
                    {
                        case Event.Balances:
                            var palletSubEvent = (MoneyPot_NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent)eventCore.Value2;
                            secondaryEvent = palletSubEvent.Value.ToString();
                            break;
                        case Event.Grandpa:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.pallet_grandpa.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                        case Event.MoneyPot:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                        case Event.Scheduler:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                        case Event.Sudo:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.pallet_sudo.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                        case Event.System:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.frame_system.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                        case Event.TransactionPayment:
                            secondaryEvent = ((MoneyPot_NetApiExt.Generated.Model.pallet_transaction_payment.pallet.EnumEvent)eventCore.Value2).Value.ToString();
                            break;
                    }

                    var newEvent = new EventDto()
                    {
                        PalletName = eventCore.Value.ToString(),
                        EventName = secondaryEvent,
                        Block = await _blockRepository.GetLastBlockAsync(),
                        Description = string.Empty
                    };
                    events.Add(newEvent);

                    eventCallback(newEvent);
                }

            }, CancellationToken.None);
        }
    }
}
