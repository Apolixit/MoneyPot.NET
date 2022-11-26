using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared.Event
{
    public interface IEventListener
    {
        EventResult Read(string hex);
        void SetDepth(int depth);
    }
}
