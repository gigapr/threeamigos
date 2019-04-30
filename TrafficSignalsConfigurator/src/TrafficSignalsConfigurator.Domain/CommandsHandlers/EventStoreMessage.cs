using System;
using Newtonsoft.Json;

namespace TrafficSignalsConfigurator.Domain.Events 
{
    public class EventStoreMessage
    {
        public string SourceId { get; set; }    
        public Event Data { get; set; }
        public string Type { get; set; }

        public EventStoreMessage(string sourceId, Event data, string type)
        {
            SourceId = sourceId;
            Data = data;
            Type = type;
        }
    }
}