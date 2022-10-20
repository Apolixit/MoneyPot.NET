using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class BlockRepositoryApi : IBlockRepository
    {
        public Task<BlockDto?> GetLastBlockAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
