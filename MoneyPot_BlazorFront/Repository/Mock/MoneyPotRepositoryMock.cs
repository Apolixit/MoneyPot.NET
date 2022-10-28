using Shared_MoneyPot;
using static MoneyPot_BlazorFront.Repository.IMoneyPotRepository;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class MoneyPotRepositoryMock : IMoneyPotRepository
    {
        private Task<IEnumerable<MoneyPotDto>> getAllAsync()
        {
            return Task.Run(() =>
            {
                return new List<MoneyPotDto>() {
                    new MoneyPotDto()
                    {
                        Hash = "0x00",
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Contributors = AccountStorage.Accounts.Skip(2).Take(2).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 200
                        }).ToList(),
                        TypeEnd = TypeEndDto.AmountLimit,
                        AmountTarget = 1000,
                        IsFinished = false
                    },
                    new MoneyPotDto()
                    {
                        Hash = "0xee",
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Contributors = AccountStorage.Accounts.Skip(1).Take(4).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 500
                        }).ToList(),
                        TypeEnd = TypeEndDto.BlockLimit,
                        BlockTarget = 80000,
                        IsFinished = false
                    },
                    new MoneyPotDto()
                    {
                        Hash = "0xff",
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Contributors = AccountStorage.Accounts.Skip(3).Take(2).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 500
                        }).ToList(),
                        TypeEnd = TypeEndDto.BlockLimit,
                        BlockTarget = 44000,
                        IsFinished = true
                    }
                }.AsEnumerable();
            });
        }

        public async Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
        {
            (await getAllAsync()).ToList().ForEach(mp => moneyPotCallback(mp));
        }

        public Task CreateMoneyPotAsync(AccountDto receiver, CreateDto creation, Action<ExtrinsicStatusDto> createCallback)
        {
            createCallback(ExtrinsicStatusDto.Waiting);
            return Task.CompletedTask;
        }

        public Task ContributeMoneyPotAsync(MoneyPotDto moneyPot, double amount, Action<ExtrinsicStatusDto> contributeCallback)
        {
            contributeCallback(ExtrinsicStatusDto.Waiting);
            return Task.CompletedTask;
        }
    }
}
