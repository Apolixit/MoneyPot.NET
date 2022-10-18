using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Service
{
    public interface IAccountService
    {
        AccountDto ConnectedAccount { get; }

        void UpdateConnectedAccount(AccountDto newAccount);
    }
}
