using System;

namespace TrafficSignalsConfigurator.Domain.Events 
{
    public abstract class Event 
    {
        public string SourceId { get; }
        public object Data { get; protected set; }

        public Event(string sourceId) 
        {
            SourceId = sourceId;
        }
    }
}