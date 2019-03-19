using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Event = TrafficSignalsConfigurator.Domain.Events.Event;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public class EventsListener : IEventsListener
    {
        
        // private const string eventsQueue = "threeamigos.events";

        private readonly IConnection _connection;
        private readonly string _eventsExchange;

        public EventsListener(IConnection connectionFactory, string eventsExchange)
        {
            _connection = connectionFactory;
            _eventsExchange = eventsExchange;
        }

        public void Listen(params string[] eventTypes)
        {
            throw new System.NotImplementedException();
        }

        // public void Publish(Event ev)
        // {
        //     using (var channel = _connection.CreateModel()) 
        //     {
        //         var data = JsonConvert.SerializeObject(ev);

        //         var body = Encoding.UTF8.GetBytes(data);

        //         channel.BasicPublish(exchange: _eventsExchange, routingKey: "", basicProperties: null, body: body);
        //     }
        // }
    }
}