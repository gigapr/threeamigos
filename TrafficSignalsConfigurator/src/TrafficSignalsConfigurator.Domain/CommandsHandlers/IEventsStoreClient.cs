using System.Threading.Tasks;
using Event = TrafficSignalsConfigurator.Domain.Events.Event;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public interface IEventsStoreClient
    {
        Task Publish(Event ev);
    }
}