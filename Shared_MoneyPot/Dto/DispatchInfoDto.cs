using MoneyPot_NetApiExt.Generated.Model.frame_support.weights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared
{
    public class DispatchInfoDto
    {
        public Pays PaysFee { get; set; }
        public DispatchClass Class { get; set; }
        public ulong Weight { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is DispatchInfoDto dto &&
                   PaysFee == dto.PaysFee &&
                   Class == dto.Class &&
                   Weight == dto.Weight;
        }
    }
}
