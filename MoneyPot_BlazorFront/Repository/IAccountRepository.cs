using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Subscribe to list of accounts
        /// </summary>
        /// <param name="moneyPotCallback">Return the account (created or changed)</param>
        /// <returns></returns>
        Task SubscribeAccountAsync(Action<AccountDto> accountCallback);
    }
}
