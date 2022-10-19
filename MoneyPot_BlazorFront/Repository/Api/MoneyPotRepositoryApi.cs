using Shared_MoneyPot;
using static MoneyPot_BlazorFront.Repository.IMoneyPotRepository;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class MoneyPotRepositoryApi : IMoneyPotRepository
    {
        public Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<ExtrinsicStatusDto> contributeCallback)
        {
            throw new NotImplementedException();
        }

        public Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<ExtrinsicStatusDto> createCallback)
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
