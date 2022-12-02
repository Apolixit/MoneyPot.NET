using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared
{
    public class PalletErrorDto
    {
        public string PalletName { get; set; } = string.Empty;
        public Enum? EventError { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
