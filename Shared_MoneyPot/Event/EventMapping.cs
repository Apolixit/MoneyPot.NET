using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using MoneyPot_NetApiExt.Generated.Model.primitive_types;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using MoneyPot_NetApiExt.Generated.Types.Base;
using MoneyPot_Shared.Extensions;
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
                Mapping = new List<IMappingElement>() { 
                    new MappingElementU128(),
                    new MappingElementU64(),
                    new MappingElementU32(),
                    new MappingElementU16(),
                    new MappingElementU8(),
                }
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
                Name = "Result",
                Mapping = new List<IMappingElement>() { new MappingElementEnumResult() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Unknown",
                Mapping = new List<IMappingElement>() { new MappingElementUnknown() }
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

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return (uint)((U128)input).Value;
        }
    }

    public class MappingElementU64 : IMappingElement
    {
        public Type ObjectType => typeof(U64);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U64)input).Value;
        }
    }

    public class MappingElementU32 : IMappingElement
    {
        public Type ObjectType => typeof(U32);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U32)input).Value;
        }
    }

    public class MappingElementU16 : IMappingElement
    {
        public Type ObjectType => typeof(U16);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U16)input).Value;
        }
    }

    public class MappingElementU8 : IMappingElement
    {
        public Type ObjectType => typeof(U8);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U8)input).Value;
        }
    }

    public class MappingElementHash : IMappingElement
    {
        //[AjunaNodeType(TypeDefEnum.Array)]
        public Type ObjectType => typeof(H256);

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((H256)input).Value.Bytes);
    }

    public class MappingElementAccount : IMappingElement
    {
        public Type ObjectType => typeof(AccountId32);

        dynamic IMappingElement.ToHuman(dynamic input) => AccountHelper.BuildAddress((AccountId32)input);
    }

    public class MappingElementEnumResult : IMappingElement
    {
        public Type ObjectType => typeof(EnumResult);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = ((EnumResult)input);
            //enumResult.Value2;
            return (enumResult.Value, enumResult.Value2.ToString());
        }
    }

    public class MappingElementEnumExt : IMappingElement
    {
        public Type ObjectType => typeof(BaseEnumType);

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = (BaseEnumType)input;
            return (enumResult.GetValue(), enumResult.GetValue2());
        }
    }

    public class MappingElementUnknown : IMappingElement
    {
        public Type ObjectType => typeof(object);

        public dynamic ToHuman(dynamic input) => input.ToString();
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
