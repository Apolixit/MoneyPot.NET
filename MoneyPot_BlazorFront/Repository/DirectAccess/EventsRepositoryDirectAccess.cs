using Ajuna.NetApi.Model.Rpc;
using Ajuna.ServiceLayer.Model;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using MoneyPot_NetApiExt.Generated.Storage;
using MoneyPot_Shared;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class EventsRepositoryDirectAccess : IEventsRepository
    {
        private readonly ISubstrateService _substrateService;

        public EventsRepositoryDirectAccess(ISubstrateService substrateService)
        {
            _substrateService = substrateService;
        }

        public Task SubscribeNewEventAsync(Action<EventDto> eventCallback)
        {

            //var storage = _substrateService.Client.StorageKeyDict;
            //foreach (var s in storage)
            //{
            //    Console.WriteLine($"{s.Key} = {s.Value}");
            //}

            //var res = storage.Where(x => x.Key.Item1 == "MoneyPot").ToList();



            return Task.CompletedTask;
        }
    }
}
