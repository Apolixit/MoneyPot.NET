using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class BlockRepositoryApi : IBlockRepository
    {
        public async Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
