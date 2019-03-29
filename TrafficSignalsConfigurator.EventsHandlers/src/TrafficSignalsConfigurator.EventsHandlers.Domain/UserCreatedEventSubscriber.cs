using RabbitMQ.Client;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Events;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain
{
    public class UserCreatedEventSubscriber : EventSubscriber<UserCreatedEvent>
    {
        public UserCreatedEventSubscriber(string rabbitMqConnectionString, IEventProcessor<UserCreatedEvent> eventProcessor) : base(rabbitMqConnectionString, eventProcessor, typeof(UserCreatedEvent).Name)
        {
        }
    }
}