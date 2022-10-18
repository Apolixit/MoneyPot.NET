using MoneyPot_NetApiExt.Generated.Model.primitive_types;

namespace Shared_MoneyPot
{
    public class MoneyPotDto
    {
        public string Hash { get; set; }
        public AccountDto Creator { get; set; } = new();
        public AccountDto Receiver { get; set; } = new();
        public bool IsFinished { get; set; } = false;
        public TypeEndDto TypeEnd { get; set; }
        public double? AmountTarget { get; set; }
        public int? BlockTarget { get; set; }
        public IList<ContributorDto> Contributors { get; set; } = new List<ContributorDto>();

        public string DisplayHash => Hash.ToString();
        //public static H256 ToH256(string hash)
        //{
        //    H256 hash256 = new H256();
        //    hash256.Create(hash);
        //    return hash256;
        //}
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