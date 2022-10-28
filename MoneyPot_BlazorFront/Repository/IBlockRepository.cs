using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Allow to subscribe to new generated blocks
        /// </summary>
        /// <param name="blockCallback">Return the new finalized block</param>
        Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback);

        /// <summary>
        /// Return the last finalized block
        /// </summary>
        /// <returns></returns>
        Task<BlockDto?> GetLastBlockAsync();

        /// <summary>
        /// Block time in millisecond
        /// </summary>
        /// <returns></returns>
        int GetBlockTime();
    }
}
