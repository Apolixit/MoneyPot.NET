using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IMoneyPotRepository
    {
        /// <summary>
        /// Get all money pots
        /// </summary>
        Task<IEnumerable<MoneyPotDto>> GetAllAsync();
    }
}
