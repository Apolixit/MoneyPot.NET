using MoneyPot_BlazorFront.Helpers;
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
            await substrateService.Client.Chain.SubscribeAllHeadsAsync((string s, Ajuna.NetApi.Model.Rpc.Header h) =>
            {
                //Console.WriteLine($"Number = {h.Number.Value} - s = {s} - h.ExtrinsicsRoot = {h.ExtrinsicsRoot} - h.StateRoot = {h.StateRoot}");
                blockCallback(new BlockDto()
                {
                    BlockHash = h.ParentHash.Value,
                    BlockNumber = (int)h.Number.Value,
                });
            });
        }
    }
}
