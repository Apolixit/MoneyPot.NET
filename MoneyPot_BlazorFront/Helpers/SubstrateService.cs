using MoneyPot_NetApiExt.Generated;
using MoneyPot_RestClient;

namespace MoneyPot_BlazorFront.Helpers
{
    public class SubstrateService : ISubstrateService
    {
        public Uri NodeUri = new Uri("ws://127.0.0.1:9944");
        private SubstrateClientExt _client;
        public SubstrateClientExt Client
        {
            get
            {
                if (_client == null)
                {
                    Console.WriteLine($"_client is null");
                    _client = new SubstrateClientExt(NodeUri);
                    Console.WriteLine($"_client = {_client}");
                } 
                return _client;
            }
        }

        //private BaseSubscriptionClient? _subscriptionClient;
        //public BaseSubscriptionClient SubscriptionClient
        //{
        //    get
        //    {
        //        if (_subscriptionClient == null) _subscriptionClient = new BaseSubscriptionClient(new System.Net.WebSockets.ClientWebSocket());
        //        return _subscriptionClient;
        //    }
        //}
    }
}
