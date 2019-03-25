using RabbitMQ.Client;
using TrafficSignalsConfigurator.Domain.Events;

namespace TrafficSignalsConfigurator.Domain.EventsHandlers
{
    public class UserCreatedEventSubscriber : EventSubscriber<UserCreatedEvent>
    {
        public UserCreatedEventSubscriber(string rabbitMqConnectionString, IEventProcessor<UserCreatedEvent> eventProcessor) : base(rabbitMqConnectionString, eventProcessor, typeof(UserCreatedEvent).Name)
        {
        }
    }
}