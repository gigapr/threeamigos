using System.Threading.Tasks;
using TrafficSignalsConfigurator.Domain.Events;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public interface IEventsStoreClient
    {
        Task Publish(EventStoreMessage ev);
    }
}