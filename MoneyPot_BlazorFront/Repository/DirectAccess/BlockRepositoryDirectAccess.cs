using Ajuna.NetApi.Model.Types.Base;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class BlockRepositoryDirectAccess : IBlockRepository
    {
        private ISubstrateService substrateService;
        public BlockRepositoryDirectAccess(ISubstrateService substrateService)
        {
            this.substrateService = substrateService;
        }

        public async Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            await substrateService.Client.Chain.SubscribeAllHeadsAsync(async (string s, Ajuna.NetApi.Model.Rpc.Header h) =>
            {
                var blockNumber = new BlockNumber();
                blockNumber.Create((uint)h.Number.Value);

                var currentHash = await this.substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
                
                blockCallback(new BlockDto()
                {
                    BlockHash = currentHash.Value,
                    BlockNumber = (int)blockNumber.Value,
                });
            });
        }
    }
}
