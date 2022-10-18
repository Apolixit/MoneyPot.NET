using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Service
{
    public class AccountService : IAccountService
    {
        private AccountDto _connectedAccount;
        public AccountDto ConnectedAccount
        {
            get
            {
                return _connectedAccount;
            }
        }

        public void UpdateConnectedAccount(AccountDto newAccount)
        {
            _connectedAccount = newAccount;
        }
    }
}
