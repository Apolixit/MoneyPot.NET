using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using MoneyPot_BlazorFront.Repository;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using Schnorrkel.Keys;
using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Helpers
{
    public static class SubstrateHelper
    {
        /// <summary>
        /// Create an `AccountId32` from seed
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="secretSeed"></param>
        /// <returns></returns>
        public static AccountId32 BuildAccountId32(string secretSeed)
        {
            MiniSecret miniSecretAccount = new MiniSecret(Utils.HexToByteArray(secretSeed), ExpandMode.Ed25519);
            var account = Account.Build(KeyType.Sr25519, miniSecretAccount.ExpandToSecret().ToBytes(), miniSecretAccount.GetPair().Public.Key);

            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(account.Value));
            return accountId32;
        }

        public static AccountDto BuildAccountDto(AccountId32 account)
        {
            var accountAddress = Utils.GetAddressFrom(account.Value.Bytes);
            var storage = AccountStorage.Accounts.FirstOrDefault(x => x.ss58Address == accountAddress);
            //if (!storage) throw new Exception("Account not found");

            return AccountStorage.ToDTO(storage);
        }
    }
}
