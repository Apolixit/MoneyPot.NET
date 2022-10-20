using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class BlockRepositoryDirectAccess : IBlockRepository
    {
        private readonly ISubstrateService _substrateService;
        private BlockDto? _lastBlock;

        public BlockRepositoryDirectAccess(ISubstrateService substrateService)
        {
            this._substrateService = substrateService;
        }

        public Task<BlockDto?> GetLastBlockAsync()
        {
            return Task.Run(() => _lastBlock);
        }

        public async Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            await _substrateService.Client.Chain.SubscribeAllHeadsAsync(async (string s, Header h) =>
            {
                var blockNumber = new BlockNumber();
                blockNumber.Create((uint)h.Number.Value);

                var currentHash = await _substrateService.Client.Chain.GetBlockHashAsync(blockNumber);
                _lastBlock = new BlockDto()
                {
                    BlockHash = currentHash.Value,
                    BlockNumber = (int)blockNumber.Value,
                };

                blockCallback(_lastBlock);
            });
        }
    }
}
