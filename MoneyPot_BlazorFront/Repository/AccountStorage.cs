using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository
{
    /// <summary>
    /// Static class with all informations about tests account
    /// </summary>
    public static class AccountStorage
    {
        // Secret Key URI `//Alice` is account:
        // Network ID:        substrate
        // Secret seed:       0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:        0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Public key(SS58): 5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        // SS58 Address:      5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY

        // Secret Key URI `//Bob` is account:
        // Network ID:        substrate
        // Secret seed:       0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:        0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Public key(SS58): 5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        // SS58 Address:      5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty

        // Secret Key URI `//Charlie` is account:
        // Network ID:        substrate
        // Secret seed:       0xbc1ede780f784bb6991a585e4f6e61522c14e1cae6ad0895fb57b9a205a8f938
        // Public key(hex):  0x90b5ab205c6974c9ea841be688864633dc9ca8a357843eeacf2314649965fe22
        // Account ID:        0x90b5ab205c6974c9ea841be688864633dc9ca8a357843eeacf2314649965fe22
        // Public key(SS58): 5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y
        // SS58 Address:      5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y

        // Secret Key URI `//Dave` is account:
        // Network ID:        substrate
        // Secret seed:       0x868020ae0687dda7d57565093a69090211449845a7e11453612800b663307246
        // Public key(hex):  0x306721211d5404bd9da88e0204360a1a9ab8b87c66c1bc2fcdd37f3c2222cc20
        // Account ID:        0x306721211d5404bd9da88e0204360a1a9ab8b87c66c1bc2fcdd37f3c2222cc20
        // Public key(SS58): 5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy
        // SS58 Address:      5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy

        // Secret Key URI `//Ferdie` is account:
        // Network ID:        substrate
        // Secret seed:       0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842
        // Public key(hex):  0x1cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c
        // Account ID:        0x1cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c
        // Public key(SS58): 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
        // SS58 Address:      5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL


        // Secret Key URI `//Eve` is account:
        // Network ID:        substrate
        // Secret seed:       0x786ad0e2df456fe43dd1f91ebca22e235bc162e0bb8d53c633e8c85b2af68b7a
        // Public key(hex):  0xe659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e
        // Account ID:        0xe659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e
        // Public key(SS58): 5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw
        // SS58 Address:      5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw

        // https://www.flaticon.com/free-icons/avatar
        private static List<(string name, string ss58Address, string publicKey, string secretSeed)> accounts;
        public static List<(string name, string ss58Address, string publicKey, string secretSeed)> Accounts
        {
            get
            {
                if (accounts == null)
                {
                    accounts = new List<(string name, string ss58Address, string publicKey, string secretSeed)>()
                    {
                        ("Alice", "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY", "0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d", "0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"),
                        ("Bob", "5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty", "0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48", "0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"),
                        ("Charlie", "5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y", "0x90b5ab205c6974c9ea841be688864633dc9ca8a357843eeacf2314649965fe22", "0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"),
                        ("Dave", "5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy", "0x306721211d5404bd9da88e0204360a1a9ab8b87c66c1bc2fcdd37f3c2222cc20", "0x868020ae0687dda7d57565093a69090211449845a7e11453612800b663307246"),
                        ("Ferdie", "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL", "0x1cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c", "0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"),
                        ("Eve", "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw", "0xe659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e", "0x786ad0e2df456fe43dd1f91ebca22e235bc162e0bb8d53c633e8c85b2af68b7a"),
                    };
                }

                return accounts;
            }
        }

        public static AccountDto ToDTO((string name, string ss58Address, string publicKey, string _secretSeed) account)
        {
            return new AccountDto(account.name, account.ss58Address, account.publicKey);
        }
    }
}
