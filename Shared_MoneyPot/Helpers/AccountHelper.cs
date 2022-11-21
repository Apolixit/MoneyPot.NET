using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using Schnorrkel.Keys;
using Shared_MoneyPot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared.Helpers
{
    public static class AccountHelper
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

        /// <summary>
        /// Get and AccountId32 from Dto
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public static AccountId32 BuildAccountId32(AccountDto accountDto)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(accountDto.Address));
            return accountId32;
        }

        public static string BuildAddress(AccountId32 account)
        {
            return Utils.GetAddressFrom(account.Value.Bytes);
        }
    }
}
