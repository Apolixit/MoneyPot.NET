using MoneyPot_BlazorFront.Service;
using MoneyPot_NetApiExt.Generated;
using MoneyPot_RestClient;

namespace MoneyPot_BlazorFront.Helpers
{
    public class SubstrateServiceMock : ISubstrateService
    {
        public bool IsConnected => true;

        public SubstrateClientExt Client
        {
            get
            {
                return null;
            }
        }

        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            isConnectedCallback(true);

            //try
            //{
            //    while (!cancellationToken.IsCancellationRequested)
            //    {
            //        isConnectedCallback(true);
            //    }
            //}
            //catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            //{

            //}
            
        }
    }
}
