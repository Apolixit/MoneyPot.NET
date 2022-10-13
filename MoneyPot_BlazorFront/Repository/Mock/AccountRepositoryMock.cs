using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class AccountRepositoryMock : IAccountRepository
    {
        public Task<List<AccountDto>> GetAll()
        {
            return Task.Run(() =>
            {
                return AccountStorage.Accounts.Select(x => new AccountDto(x.name, x.ss58Address, x.publicKey).WithBalance(1000)).ToList();
            });
        }
    }
}
