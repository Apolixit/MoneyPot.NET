using Ajuna.NetApi.Model.Extrinsics;
using MoneyPot_NetApiExt.Generated;
using MoneyPot_RestClient;

namespace MoneyPot_BlazorFront.Helpers
{
    public class SubstrateService : ISubstrateService
    {
        private readonly IConfiguration Configuration;
        public SubstrateService(IConfiguration configuration)
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




    }
}
