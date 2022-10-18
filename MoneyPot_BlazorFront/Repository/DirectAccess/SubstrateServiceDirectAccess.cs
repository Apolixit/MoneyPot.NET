using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.ServiceLayer;
using Ajuna.ServiceLayer.Storage;
using MoneyPot_BlazorFront.Repository;
using MoneyPot_BlazorFront.Repository.DirectAccess;
using MoneyPot_BlazorFront.Repository.Mock;
using MoneyPot_NetApiExt.Generated;
using MoneyPot_RestClient;
using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Service
{
    public class SubstrateServiceDirectAccess : ISubstrateService
    {
        private readonly IConfiguration Configuration;
        public SubstrateServiceDirectAccess(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly Uri NodeUri = new Uri("ws://127.0.0.1:9944"); //Configuration["uriEndpoint"]
        public bool IsConnected => Client.IsConnected;

        private SubstrateClientExt _client;
        public SubstrateClientExt Client
        {
            get
            {
                if (_client == null)
                {
                    Console.WriteLine($"_client is null");
                    _client = new SubstrateClientExt(NodeUri, ChargeTransactionPayment.Default());
                    Console.WriteLine($"_client = {_client}");
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
                        } catch(Exception ex)
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
