using System.Threading.Tasks;
using TrafficSignalsConfigurator.Domain.Events;

namespace TrafficSignalsConfigurator.Domain.EventsHandlers
{
    public interface IEventProcessor<T> where T : Event
    {
        Task ProcessAsync(T @event);        
    }
}