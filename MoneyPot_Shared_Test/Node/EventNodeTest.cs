using Ajuna.NetApi.Model.Types.Primitive;
using MoneyPot_Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared_Test.Node
{
    public class EventNodeTest
    {
        [Test]
        public void EventNode_Empty_ShouldRenderNullEventResult()
        {
            Assert.IsNull(EventResult.Create(EventNode.Empty));
        }

        [Test]
        public void EventNode_WithoutPalletName_ShouldRenderNullEventResult()
        {
            var nodeWithoutPalletName = EventNode.Create().AddData(new U128());
            Assert.IsNull(EventResult.Create(nodeWithoutPalletName));
        }
    }
}
