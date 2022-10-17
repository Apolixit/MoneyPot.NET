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
    }
}
