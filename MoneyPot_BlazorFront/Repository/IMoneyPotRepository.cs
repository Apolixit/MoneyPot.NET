using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IMoneyPotRepository
    {
        /// <summary>
        /// Get all money pots
        /// </summary>
        Task<IEnumerable<MoneyPotDto>> GetAllAsync();
        
        /// <summary>
        /// Subscribe to list of money pot
        /// </summary>
        /// <param name="moneyPotCallback"></param>
        /// <returns></returns>
        Task SubscribeMoneyPotsAsync(Action<IEnumerable<MoneyPotDto>> moneyPotCallback);
    }
}
