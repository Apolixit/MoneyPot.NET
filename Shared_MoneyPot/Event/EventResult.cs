﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared.Event
{
    public class EventResult
    {
        public static EventResult Create(string palletEventName, string eventName)
        {
            return Create(palletEventName, eventName, new List<EventDetailsResult>());
        }

        public static EventResult Create(string palletEventName, string eventName, IList<EventDetailsResult>? details)
        {
            var result = new EventResult();
            result.AddEvent(palletEventName);
            result.AddEvent(eventName);
            result.Details = details;

            return result;
        }

        public string? PalletEventName
        {
            get
            {
                string? p;
                _events.TryGetValue(0, out p);
                return p;
            }
        }
        public string? EventName {
            get
            {
                string? p;
                _events.TryGetValue(1, out p);
                return p;
            }
        }

        private IDictionary<int, string> _events = new Dictionary<int, string>();
        public IList<EventDetailsResult>? Details { get; set; } = new List<EventDetailsResult>();

        public void AddEvent(string ev)
        {
            int nextIndex = _events.Count > 0 ? _events.LastOrDefault().Key + 1 : default(int);
            _events.Add(nextIndex, ev);
        }

        public void AddDetails(EventMappingElem mappingCategory, IMappingElement mapper, dynamic value)
        {
            if (Details == null) Details = new List<EventDetailsResult>();

            Details.Add(mappingCategory.ToEventDetailsResult(value, mapper));
        }


        public override bool Equals(object? obj)
        {
            return obj is EventResult result &&
                   PalletEventName == result.PalletEventName &&
                   EventName == result.EventName &&
                   Details.SequenceEqual(result.Details);
        }
    }

    public class EventDetailsResult
    {
        /// <summary>
        /// Use for reflexion and call dynamic Razor component
        /// </summary>
        public string ComponentName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public dynamic? Value { get; set; }

        public override bool Equals(object? obj)
        {
            var b = obj is EventDetailsResult;
            var res = (EventDetailsResult)obj;
            var bb = ComponentName == res.ComponentName;
            var bbb = Title == res.Title;
            var bbbb = EqualityComparer<dynamic>.Default.Equals(Value, res.Value);

            //return b && bb && bbb && bbbb;
            return obj is EventDetailsResult result &&
                   ComponentName == result.ComponentName &&
                   Title == result.Title &&
                   EqualityComparer<dynamic>.Default.Equals(Value, result.Value);
        }
    }
}
