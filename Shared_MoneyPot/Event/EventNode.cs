using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared.Event
{
    public class EventNode
    {
        public static EventNode Empty => Create(null);
        public bool IsEmpty => Data == null;

        //public int Id { get; set; }
        //public string Name { get; set; } = string.Empty;
        public IType Data { get; set; }
        public dynamic HumanData { get; set; } = string.Empty;
        //public int Level { get; set; }
        public LinkedList<EventNode> Children { get; set; } = new LinkedList<EventNode>();

        protected EventNode() { }
        //protected EventNode(dynamic data)
        //{
        //    Data = data;
        //}

        //protected EventNode(dynamic data, dynamic humanData)
        //{
        //    Data = data;
        //    HumanData = humanData;
        //}

        public static EventNode Create()
        {
            return new EventNode();
        }

        public static EventNode Create(IType data)
        {
            return Create().SetData(data);
        }

        public static EventNode Create(dynamic data, dynamic humanData)
        {
            return Create().SetData(data, humanData);
        }

        public EventNode SetData(IType data)
        {
            Data = data;
            return this;
        }
        public EventNode SetData(IType data, dynamic humanData)
        {
            Data = data;
            HumanData = humanData;
            return this;
        }

        //public void AddChild(dynamic data)
        //{
        //    Children.AddFirst(new EventNode(data));
        //}

        public void AddChild(EventNode eventNode)
        {
            Children.AddLast(eventNode);
        }
    }
}
