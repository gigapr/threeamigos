using TrafficSignalsConfigurator.Domain.Events;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public interface IEventsListener
    {
        void Listen(params string[] eventTypes);
    }
}