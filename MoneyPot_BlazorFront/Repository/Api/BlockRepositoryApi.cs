using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Api
{
    public class BlockRepositoryApi : IBlockRepository
    {
        public void SubscribeNewBlocks(Action<BlockDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
