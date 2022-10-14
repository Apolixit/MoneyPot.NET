using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Allow to subscribe to new generated blocks
        /// </summary>
        /// <param name="blockCallback"></param>
        Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback);
    }
}
