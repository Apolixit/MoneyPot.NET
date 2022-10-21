using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using MoneyPot_BlazorFront.Repository;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using Schnorrkel.Keys;
using Shared_MoneyPot;
using System.Numerics;

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

        public static Account BuildAccount(AccountDto accountDto)
        {
            MiniSecret miniSecretAccount = new MiniSecret(Utils.HexToByteArray(AccountStorage.FromDto(accountDto).secretSeed), ExpandMode.Ed25519);
            var res = Account.Build(KeyType.Sr25519, miniSecretAccount.ExpandToSecret().ToBytes(), miniSecretAccount.GetPair().Public.Key);
            return res;
        }

        public static AccountDto BuildAccountDto(AccountId32 account)
        {
            var accountAddress = Utils.GetAddressFrom(account.Value.Bytes);
            var storage = AccountStorage.Accounts.FirstOrDefault(x => x.ss58Address == accountAddress);
            //if (!storage) throw new Exception("Account not found");

            return AccountStorage.ToDTO(storage);
        }

        public static AccountDto BuildAccountDtoFromAddress(string address) => AccountStorage.ToDTO(AccountStorage.Accounts.FirstOrDefault(x => x.ss58Address == address));

        public static string getChangesetData(StorageChangeSet storageChangeSet)
        {
            if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
            {
                throw new Exception("Couldn't update account information. Please check 'CallBackAccountChange'");
            }


            var hexString = storageChangeSet.Changes[0][1];

            //if (string.IsNullOrEmpty(hexString))
            //{
            //    throw new Exception("Unable to retrieve data");
            //}

            return hexString;
        }

        public static U ToPrimitive<T, U, V>(T input, Func<T, byte[]> convert)
            where U : BasePrim<V>, new()
        {
            var primVal = new U();
            primVal.Create(convert(input));

            return primVal;
        }
    }
}
