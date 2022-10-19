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

        /// <summary>
        /// Create a new money pot
        /// </summary>
        /// <param name="receiver">The beneficiary</param>
        /// <param name="amount">The contribution amount</param>
        /// <param name="createCallback">Callback method triggered at different substrate state (based on ExtrinsicStatus)</param>
        /// <returns></returns>
        Task CreateMoneyPotAsync(AccountDto receiver, double amount, Action<string> createCallback);

        /// <summary>
        /// Contribute to an existing money pot
        /// </summary>
        /// <param name="moneyPot">The money pot to contribute</param>
        /// <param name="amount">The contribution amount</param>
        /// <param name="contributeCallback">Callback method triggered at different substrate state (based on ExtrinsicStatus)</param>
        /// <returns></returns>
        Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<string> contributeCallback);
    }
}
