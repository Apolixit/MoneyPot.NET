using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Get all available accounts for testing
        /// </summary>
        /// <returns></returns>
        Task<List<AccountDto>> GetAll();
    }
}
