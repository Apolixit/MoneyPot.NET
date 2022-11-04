using Shared_MoneyPot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared
{
    public class EventDto
    {
        public BlockDto Block { get; set; } = new BlockDto();
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
