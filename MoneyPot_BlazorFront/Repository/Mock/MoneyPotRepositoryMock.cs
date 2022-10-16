using Shared_MoneyPot;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class MoneyPotRepositoryMock : IMoneyPotRepository
    {
        public Task<IEnumerable<MoneyPotDto>> GetAllAsync()
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
                            Amount = 500
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
                        BlockTarget = 80,
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
                        BlockTarget = 44,
                        IsFinished = true
                    }
                }.AsEnumerable();
            });
        }

        public async Task SubscribeMoneyPotsAsync(Action<MoneyPotDto> moneyPotCallback)
        {
            //moneyPotCallback(await GetAllAsync());
            (await GetAllAsync()).ToList().ForEach(mp => moneyPotCallback(mp));
        }
    }
}
