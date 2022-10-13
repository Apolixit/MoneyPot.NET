using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class BlockRepositoryDirectAccess : IBlockRepository
    {
        public void SubscribeNewBlocks(Action<BlockDto> blockCallback)
        {
            throw new NotImplementedException();
        }
    }
}
