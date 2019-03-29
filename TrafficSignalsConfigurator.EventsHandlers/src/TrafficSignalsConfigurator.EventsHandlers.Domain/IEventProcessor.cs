using System.Threading.Tasks;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Events;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain
{
    public interface IEventProcessor<T> where T : Event
    {
        Task ProcessAsync(T @event);        
    }
}