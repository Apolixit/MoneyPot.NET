namespace Shared_MoneyPot
{
    public class MoneyPotDto
    {
        public string Hash { get; set; } = string.Empty;
        public AccountDto Creator { get; set; } = new();
        public AccountDto Receiver { get; set; } = new();
        public bool IsFinished { get; set; } = false;
        public TypeEndDto TypeEnd { get; set; }
        public double? AmountTarget { get; set; }
        public int? BlockTarget { get; set; }
        public IList<ContributorDto> Contributors { get; set; } = new List<ContributorDto>();

        public override bool Equals(object? obj)
        {
            return obj is MoneyPotDto dto &&
                   Hash == dto.Hash;
        }
    }

    public class ContributorDto
    {
        public AccountDto Contributor { get; set; } = new AccountDto();
        public double Amount { get; set; }
    }

    public enum TypeEndDto
    {
        AmountLimit,
        BlockLimit,
    }
}