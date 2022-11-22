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
        /// <summary>
        /// Parse the hexadecimal event to a "friendly" event structure
        /// </summary>
        /// <param name="hex">Event hexa</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Event hexa is empty</exception>
        /// <exception cref="NullReferenceException"></exception>
        public EventResult Read(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)} is not set");

            var eventReceived = new EventRecord();
            eventReceived.Create(Utils.HexToByteArray(hex));

            if (eventReceived == null)
                throw new ArgumentNullException($"{nameof(eventReceived)} has not been instanciate properly, maybe due to invalid hex parameter");

            var mapping = new EventMapping();
            var eventResult = new EventResult();

            var eventCore = eventReceived.Event;
            //var eventPhase = eventReceived.Phase;
            //var eventTopic = eventReceived.Topics;

            //Current enum event
            BaseEnumType? baseExt = eventCore;

            while (baseExt != null)
            {
                IType? childValue = baseExt.GetValue2();

                if(childValue == null)
                    throw new ArgumentNullException($"{nameof(childValue)} is empty");

                if(baseExt.GetValue() == null)
                    throw new ArgumentNullException($"Current event has no value");

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
                            var (mappingCategory, mapper) = mapping.Search(genericArgs[i]);
                            eventResult.AddDetails(mappingCategory, mapper, childValue.GetValueArray()[i]);
                        }
                    }
                    else
                    {
                        var (mappingCategory, mapper) = mapping.Search(childValue.GetType());
                        eventResult.AddDetails(mappingCategory, mapper, childValue);
                    }
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
