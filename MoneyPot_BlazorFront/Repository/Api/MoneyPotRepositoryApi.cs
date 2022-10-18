using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class MoneyPotRepositoryApi : IMoneyPotRepository
    {
        public Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<string> contributeCallback)
        {
            throw new NotImplementedException();
        }

        public Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<string> createCallback)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MoneyPotDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
        {
            throw new NotImplementedException();
        }
    }
}
