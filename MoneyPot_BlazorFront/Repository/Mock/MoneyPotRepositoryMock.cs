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
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Contributors = AccountStorage.Accounts.Skip(2).Take(2).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 500
                        }).ToList(),
                        TypeEnd = TypeEndDto.AmountLimit,
                        IsFinished = false
                    },
                    new MoneyPotDto()
                    {
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Contributors = AccountStorage.Accounts.Skip(1).Take(4).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 500
                        }).ToList(),
                        TypeEnd = TypeEndDto.AmountLimit,
                        IsFinished = false
                    },
                    new MoneyPotDto()
                    {
                        Creator = AccountStorage.ToDTO(AccountStorage.Accounts[0]),
                        Receiver = AccountStorage.ToDTO(AccountStorage.Accounts[1]),
                        Contributors = AccountStorage.Accounts.Skip(3).Take(2).Select(x => new ContributorDto() {
                            Contributor = AccountStorage.ToDTO(x),
                            Amount = 500
                        }).ToList(),
                        TypeEnd = TypeEndDto.BlockLimit,
                        IsFinished = true
                    }
                }.AsEnumerable();
            });
        }

        public Task SubscribeMoneyPotsAsync(Action<IEnumerable<MoneyPotDto>> moneyPotCallback)
        {
            throw new NotImplementedException();
        }
    }
}
