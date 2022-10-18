using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IMoneyPotRepository
    {     
        /// <summary>
        /// Subscribe to list of money pot
        /// </summary>
        /// <param name="moneyPotCallback"></param>
        /// <returns></returns>
        Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback);

        Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<string> createCallback);
        Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<string> contributeCallback);
    }
}
