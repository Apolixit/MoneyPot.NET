using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class AccountRepositoryApi : IAccountRepository
    {
        public Task SubscribeAccountAsync(Action<AccountDto> accountCallback)
        {
            throw new NotImplementedException();
        }
    }
}
