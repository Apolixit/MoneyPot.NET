namespace Shared_MoneyPot
{
    public class MoneyPotDto
    {
        public AccountDto Creator { get; set; } = new();
        public AccountDto Receiver { get; set; } = new();
        public bool IsFinished { get; set; } = false;
        public TypeEndDto TypeEnd { get; set; }
        public IList<ContributorDto> Contributors { get; set; } = new List<ContributorDto>();
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