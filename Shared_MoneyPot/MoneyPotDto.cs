using MoneyPot_NetApiExt.Generated.Model.primitive_types;

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

        public string DisplayHash => Hash.ToString();

        /// <summary>
        /// Return the sum of all contributions
        /// </summary>
        /// <returns></returns>
        public double SumContribution()
        {
            if (Contributors == null) return 0;
            return Contributors.Sum(x => x.Amount);
        }
       
        public override bool Equals(object? obj)
        {
            return obj is MoneyPotDto dto &&
                   Hash == dto.Hash;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class ContributorDto
    {
        public AccountDto Contributor { get; set; } = new AccountDto();
        public double Amount { get; set; }
    }

    public class CreateDto
    {
        public string ReceiverAddress { get; set; } = string.Empty;
        public double TargetAmount { get; set; }
    }

    public enum TypeEndDto
    {
        AmountLimit,
        BlockLimit,
    }
}