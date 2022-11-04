using MoneyPot_Shared;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class EventsRepositoryMock : IEventsRepository
    {
        private readonly IBlockRepository _blockRepository;

        public EventsRepositoryMock(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public Task SubscribeNewEventAsync(Action<EventDto> eventCallback)
        {
            var timer = new System.Timers.Timer(6_000)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += async (sender, e) =>
            {
                var fakeEvent = await generateFakeEventAsync();
                if(fakeEvent != null)
                    eventCallback(fakeEvent);
            };

            return Task.CompletedTask;
        }

        private async Task<EventDto> generateFakeEventAsync()
        {
            var lastBlock = await _blockRepository.GetLastBlockAsync();
            if (lastBlock == null) return null;

            return new EventDto()
            {
                Block = lastBlock,
                EventName = "Todo...",
                Description = "Item description...",
            };
        }
    }
}
