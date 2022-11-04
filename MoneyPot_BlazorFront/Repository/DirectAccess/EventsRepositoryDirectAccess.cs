using MoneyPot_Shared;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class EventsRepositoryDirectAccess : IEventsRepository
    {
          public Task SubscribeNewEventAsync(Action<EventDto> eventCallback)
        {
            throw new NotImplementedException();
        }
    }
}
