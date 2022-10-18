using MoneyPot_BlazorFront.Helpers;
using MoneyPot_BlazorFront.Service;
using MoneyPot_NetApiExt.Generated.Model.frame_system;
using MoneyPot_NetApiExt.Generated.Model.pallet_balances;
using MoneyPot_NetApiExt.Generated.Storage;
using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.DirectAccess
{
    public class AccountRepositoryDirectAccess : IAccountRepository
    {
        private ISubstrateService substrateService;
        private IList<AccountDto> accounts = new List<AccountDto>();

        public AccountRepositoryDirectAccess(ISubstrateService substrateService)
        {
            this.substrateService = substrateService;
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var accounts = new List<AccountDto>();
            foreach (var storageAccount in AccountStorage.Accounts)
            {
                var account = new AccountDto(storageAccount.name, storageAccount.ss58Address, storageAccount.publicKey);
                AccountData accountData = await this.substrateService.Client.BalancesStorage.Account(SubstrateHelper.BuildAccountId32(account), CancellationToken.None);

                account.Balance = (double)accountData.Free.Value;
                accounts.Add(account);
            }
            //BalancesStorage.AccountParams(SubstrateHelper.BuildAccountId32(account))
            //substrateService.Client.MoneyPotStorage.

            return accounts;
        }

        public async Task SubscribeAccountAsync(Action<AccountDto> accountCallback)
        {
            foreach (var storageAccount in AccountStorage.Accounts)
            {
                var account = new AccountDto(storageAccount.name, storageAccount.ss58Address, storageAccount.publicKey);
                accounts.AddOrUpdate(account);
                accountCallback(account);

                await substrateService.Client.SubscribeStorageKeyAsync(SystemStorage.AccountParams(SubstrateHelper.BuildAccountId32(account)), async (subscriptionId, storageChangeSet) =>
                {
                    var hexString = SubstrateHelper.getChangesetData(storageChangeSet);
                    if (String.IsNullOrEmpty(hexString)) return;

                    var accountInfo = new AccountInfo();
                    accountInfo.Create(hexString);

                    account.Balance = (double)accountInfo.Data.Free.Value;
                    accounts.AddOrUpdate(account);
                    accountCallback(account);
                }, CancellationToken.None);
            }
        }
    }
}
