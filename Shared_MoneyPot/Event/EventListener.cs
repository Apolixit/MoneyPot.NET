using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using MoneyPot_NetApiExt.Generated.Model.frame_system;
using MoneyPot_NetApiExt.Generated.Model.sp_core.crypto;
using MoneyPot_Shared.Extensions;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared.Event
{
    public class EventListener : IEventListener
    {
        public EventResult Read(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)} is not set");

            var eventReceived = new EventRecord();
            eventReceived.Create(Utils.HexToByteArray(hex));

            if (eventReceived == null)
                throw new NullReferenceException($"{nameof(eventReceived)} has not been instanciate properly, maybe due to invalid hex parameter");

            var mapping = new EventMapping();
            var eventResult = new EventResult();

            //var eventPhase = eventReceived.Phase;
            var eventCore = eventReceived.Event;
            //var eventTopic = eventReceived.Topics;

           
            BaseEnumType? baseExt = eventCore;

            var events = new List<BaseEnumType>();
            while (baseExt != null)
            {
                IType? childValue = baseExt.GetValue2();
                eventResult.AddEvent(baseExt.GetValue().ToString());

                if (!(childValue is BaseEnumType))
                {
                    // We are not anymore in an event, let's dig into Rust enum details
                    baseExt = null;
                    
                    if (childValue.GetType().IsGenericType)
                    {
                        var genericArgs = childValue.GetType().GenericTypeArguments;
                        for (int i = 0; i < genericArgs.Length; i++)
                        {
                            //var res = mapping.Elements.FirstOrDefault(x => x.Mapping.ObjectType == genericArgs[i]);
                            var (mappingCategory, mapper) = mapping.Search(genericArgs[i]);
                            //eventResult.Details.Add(res.Mapping.ToEventDetailsResult(childValue.GetValueArray()[i]));
                            eventResult.AddDetails(mappingCategory, mapper, childValue.GetValueArray()[i]);
                        }
                    }
                    else
                    {
                        //var res = mapping.Elements.FirstOrDefault(x => x.Mapping.ObjectType == childValue.GetType());
                        // Check v2.GetValue() or v2.GetValueArray()
                        var (mappingCategory, mapper) = mapping.Search(childValue.GetType());
                        //eventResult.Details.Add(mappingCategory.Mapping.ToEventDetailsResult(childValue.GetValue()));
                        eventResult.AddDetails(mappingCategory, mapper, childValue);
                    }

                    // Si pas BaseTuple => erreur ou ajout en toString() dans le tableau
                }
                else
                {
                    baseExt = (BaseEnumType)childValue;
                }
            }

            return eventResult;
        }
    }
}
