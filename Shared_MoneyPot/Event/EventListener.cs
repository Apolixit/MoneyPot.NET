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
using System.Xml.Linq;

namespace MoneyPot_Shared.Event
{
    public class EventListener : IEventListener
    {
        protected EventMapping mapping = new EventMapping();

        // Build tree with selected depth
        protected int depth = 2;

        public void SetDepth(int depth)
        {
            this.depth = depth;
        }

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

            var eventResult = new EventResult();

            var eventCore = eventReceived.Event;
            //var eventPhase = eventReceived.Phase;
            //var eventTopic = eventReceived.Topics;

            //Current enum event
            BaseEnumType? baseExt = eventCore;
            //0x9A0100000000000001A06D6F6E6579706F74C81DB64C632F917AF72DFF41B268A9DE40374D66FF9CD2AE87D304CB36A292FB00

            EventNode node = EventNode.Empty;
            VisitNode(node, eventResult, eventCore);
            //while (baseExt != null)
            //{
            //    IType? childValue = baseExt.GetValue2();

            //    if (childValue == null)
            //        throw new ArgumentNullException($"{nameof(childValue)} is empty");

            //    if (baseExt.GetValue() == null)
            //        throw new ArgumentNullException($"Current event has no value");

            //    VisitContent(eventResult, childValue);

            //    //eventResult.AddEvent(baseExt.GetValue().ToString());

                
            //}

            //while (baseExt != null)
            //{
            //    IType? childValue = baseExt.GetValue2();

            //    if(childValue == null)
            //        throw new ArgumentNullException($"{nameof(childValue)} is empty");

            //    if(baseExt.GetValue() == null)
            //        throw new ArgumentNullException($"Current event has no value");

            //    eventResult.AddEvent(baseExt.GetValue().ToString());

            //    if (!(childValue is BaseEnumType))
            //    {
            //        // We are not anymore in an event, let's dig into Rust enum details
            //        baseExt = null;
            //        VisitContent(eventResult, childValue);
            //    }
            //    else
            //    {
            //        baseExt = (BaseEnumType)childValue;
            //    }
            //}

            return eventResult;
        }

        

        private void VisitNode(EventNode node, EventResult eventResult, IType? value)
        {
            if (!(value is BaseEnumType))
            {
                VisitNodePrimitive(node, eventResult, value);
            }
            else
            {
                var val = value.GetValue();
                eventResult.AddEvent(val.ToString());

                var childNode = EventNode.Create(value, val);
                if (node.IsEmpty)
                {
                    node.SetData(value, val);
                    VisitNode(node, eventResult, ((BaseEnumType)value).GetValue2());
                }
                else
                {
                    VisitNode(childNode, eventResult, ((BaseEnumType)value).GetValue2());
                    node.AddChild(childNode);
                }

                
            }
        }

        private void VisitNodePrimitive(EventNode node, EventResult eventResult, IType? value)
        {
            if (value.GetType().IsGenericType)
            {
                VisitNodeGeneric(node, eventResult, value);
            }
            else
            {
                var (mappingCategory, mapper) = mapping.Search(value.GetType());
                eventResult.AddDetails(mappingCategory, mapper, value);

                node.AddChild(EventNode.Create(value, mapper.ToHuman(value)));
            }
        }

        private void VisitNodeGeneric(EventNode node, EventResult eventResult, IType? value)
        {
            var genericArgs = value.GetType().GenericTypeArguments;
            for (int i = 0; i < genericArgs.Length; i++)
            {
                
                    IType? currentValue = null;
                if (value.GetValue().GetType().IsArray)
                    currentValue = (IType)value.GetValueArray()[i];
                else
                    currentValue = (IType)value.GetValue();

                if (genericArgs[i].IsGenericType)
                {
                    var childNode = EventNode.Create(currentValue);
                    node.AddChild(childNode);

                    VisitNode(childNode, eventResult, currentValue);
                } else
                {
                    VisitNode(node, eventResult, currentValue);
                }
                // Si generic type => add child sinon ne rien faire
                //var childNode = EventNode.Create(currentValue);
                //node.AddChild(childNode);

                //VisitChildNode(node, eventResult, value, i);
                //// Loop again until it's not a generic type anymore ?
                //if (genericArgs[i].IsGenericType)
                //{
                //    VisitChildNode(node, eventResult, value, i);
                //}
                //else
                //{
                //    VisitChildNode(node, eventResult, value, i);
                //    //var (mappingCategory, mapper) = mapping.Search(genericArgs[i]);
                //    //eventResult.AddDetails(mappingCategory, mapper, value.GetValueArray()[i]);
                //    //if (value.GetValue().GetType().IsArray)
                //    //    VisitNode(node, eventResult, (IType)value.GetValueArray()[i]);
                //    //else
                //    //    VisitNode(node, eventResult, (IType)value.GetValue());
                //}
            }
        }

        //private void VisitChildNode(EventNode node, EventResult eventResult, IType? value, int i)
        //{
        //    IType? currentValue = null;
        //    if (value.GetValue().GetType().IsArray)
        //        currentValue = (IType)value.GetValueArray()[i];
        //    else
        //        currentValue = (IType)value.GetValue();

        //    // Si generic type => add child sinon ne rien faire
        //    //var childNode = EventNode.Create(currentValue);
        //    //node.AddChild(childNode);
        //    VisitNode(node, eventResult, currentValue);
        //}
    }
}
