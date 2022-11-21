using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using MoneyPot_NetApiExt.Generated.Model.primitive_types;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using MoneyPot_NetApiExt.Generated.Types.Base;
using MoneyPot_Shared.Helpers;
using static MoneyPot_Shared.Event.EventMappingElem;

namespace MoneyPot_Shared.Event
{
    public class EventMapping
    {
        protected IList<EventMappingElem> Elements { get; set; }

        public EventMapping()
        {
            Elements = new List<EventMappingElem>();
            Elements.Add(new EventMappingElem()
            {
                Name = "Amount",
                Mapping = new List<IMappingElement>() { new MappingElementU128() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Account",
                Mapping = new List<IMappingElement>() { new MappingElementAccount() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Hash",
                Mapping = new List<IMappingElement>() { new MappingElementHash() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Hash",
                Mapping = new List<IMappingElement>() { new MappingElementHash() }
            });
        }
    
        public (EventMappingElem, IMappingElement) Search(Type searchType)
        {
            foreach(var elem in Elements)
            {
                var mapped = elem.Mapping.FirstOrDefault(x => x.ObjectType == searchType);
                if(mapped != null)
                {
                    return (elem, mapped);
                }
            }

            // TODO: refacto this ugly line
            return (Elements.Last(), Elements.Last().Mapping.Last());
        }
    }

    public interface IMappingElement
    {
        public Type ObjectType { get; }
        public dynamic ToHuman(dynamic input);
    }

    public class MappingElementU128 : IMappingElement
    {
        public Type ObjectType => typeof(U128);

        public Func<U128, uint> ToHuman
        {
            get
            {
                return (U128 input) => (uint)input.Value;
            }
        }

        //public EventDetailsResult ToEventDetailsResult(dynamic input)
        //{
        //    return new EventDetailsResult()
        //    {
        //        Title = "Amount",
        //        ComponentName = "Amount",
        //        Value = ToHuman((U128)input)
        //    };
        //}

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return (uint)((U128)input).Value;
        }
    }

    public class MappingElementHash : IMappingElement
    {
        public Type ObjectType => typeof(H256);
        // [AjunaNodeType(TypeDefEnum.Array)]
        //public Func<H256, string> ToHuman
        //{
        //    get
        //    {
        //        return (H256 input) => Utils.Bytes2HexString(input.Value.Bytes);
        //    }
        //}

        //public EventDetailsResult ToEventDetailsResult(dynamic input)
        //{
        //    return new EventDetailsResult()
        //    {
        //        Title = "Hash",
        //        ComponentName = "Hash",
        //        Value = ToHuman((H256)input)
        //    };
        //}

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return Utils.Bytes2HexString(((H256)input).Value.Bytes);
        }
    }

    public class MappingElementAccount : IMappingElement
    {
        public Type ObjectType => typeof(AccountId32);

        //public Func<AccountId32, string> ToHuman
        //{
        //    get
        //    {
        //        return (AccountId32 account) => AccountHelper.BuildAddress(account);
        //    }
        //}

        //public EventDetailsResult ToEventDetailsResult(dynamic input)
        //{
        //    return new EventDetailsResult()
        //    {
        //        Title = "Account",
        //        ComponentName = "Account",
        //        Value = ToHuman((AccountId32)input)
        //    };
        //}

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return AccountHelper.BuildAddress((AccountId32)input);
        }
    }

    public class MappingElementUnknown : IMappingElement
    {
        public Type ObjectType => throw new NotImplementedException();

        //public EventDetailsResult ToEventDetailsResult(dynamic input)
        //{
        //    return new EventDetailsResult()
        //    {
        //        Title = "Unknown",
        //        ComponentName = "Unknown",
        //        Value = input.toString()
        //    };
        //}

        public dynamic ToHuman(dynamic input)
        {
            return input.ToString();
        }
    }
    public class EventMappingElem
    {
        public string Name { get; set; }
        //public Type ObjectType { get; set; }
        public IList<IMappingElement> Mapping { get; set; }



        public EventDetailsResult ToEventDetailsResult(dynamic input, IMappingElement mapping)
        {
            return new EventDetailsResult()
            {
                Title = Name,
                ComponentName = Name,
                Value = mapping.ToHuman(input)
            };
        }

    }

    public class Conversion
    {
        public uint Map(U128 input)
        {
            return (uint)input.Value;
        }

        public uint Map(U16 input)
        {
            return (uint)input.Value;
        }

        public string Map(AccountId32 input)
        {
            return "toto";
        }
    }
}
