using Substrate.NetApi.Model.Extrinsics;
using MoneyPot_NetApiExt.Generated;

namespace MoneyPot_BlazorFront.Service
{
    public class SubstrateServiceDirectAccess : ISubstrateService
    {
        private readonly Uri _nodeUri;
        private SubstrateClientExt? _client;

        public SubstrateServiceDirectAccess(IConfiguration configuration)
        {
            _nodeUri = new Uri(configuration.GetValue<string>("uriEndpoint"));
        }

        public bool IsConnected => Client.IsConnected;

        public SubstrateClientExt Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new SubstrateClientExt(_nodeUri, ChargeTransactionPayment.Default());
                }
                return _client;
            }
        }
        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while(!cancellationToken.IsCancellationRequested)
                {
                    
                    isConnectedCallback(Client.IsConnected);
                    if(!Client.IsConnected)
                    {
                        try
                        {
                            await Client.ConnectAsync(cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            // TODO
                            isConnectedCallback(Client.IsConnected);
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
                }
            } catch(OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {

            }
        }
    }
}
