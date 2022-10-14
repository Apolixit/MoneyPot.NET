using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class MoneyPotRepositoryApi : IMoneyPotRepository
    {
        public Task<IEnumerable<MoneyPotDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubscribeMoneyPotsAsync(Action<IEnumerable<MoneyPotDto>> moneyPotCallback)
        {
            throw new NotImplementedException();
        }
    }
}
