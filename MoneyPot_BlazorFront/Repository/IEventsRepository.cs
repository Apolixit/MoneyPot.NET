using MoneyPot_Shared;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IEventsRepository
    {
        /// <summary>
        /// Subscribe to new substrate extrinsics
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SubscribeNewEventAsync(Action<EventDto> eventCallback);
    }
}
