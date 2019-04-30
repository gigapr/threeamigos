using System;
using System.IO;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Events;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain
{
    public class EventSubscriber<T> where T : Event
    {
        private IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        private  EventingBasicConsumer _consumer;
        private IEventProcessor<T> _eventProcessor;
        private string _eventType;

        public EventSubscriber(string rabbitMqConnectionstring, IEventProcessor<T> eventProcessor, string eventType)
        {
             _connectionFactory = new ConnectionFactory() 
            { 
                Uri = new System.Uri(rabbitMqConnectionstring),
                RequestedHeartbeat = 30
            };

            _eventProcessor = eventProcessor;
            _eventType = eventType;

            // Connect();
        }

        private void Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            _connection.ConnectionShutdown += Connection_ConnectionShutdown;
        
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_eventType, true, false, false, null);
        
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += Consumer_Received;
            _channel.BasicConsume(_eventType, true, _consumer);
        }
    
        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var content = Encoding.UTF8.GetString(e.Body);
            
                 _eventProcessor.ProcessAsync(JsonConvert.DeserializeObject<T>(content));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        ~EventSubscriber()  
        {
            Cleanup();
        }
        
        private void Cleanup()
        {
            try
            {
                if (_channel != null && _channel.IsOpen)
                {
                    _channel.Close();
                    _channel = null;
                }
        
                if (_connection != null && _connection.IsOpen)
                {
                    _connection.Close();
                    _connection = null;
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex);
                // Close() may throw an IOException if connection
                // dies - but that's ok (handled by reconnect)
            }
        }

        private  void Connection_ConnectionShutdown (object sender, ShutdownEventArgs e) 
        {
            Console.WriteLine ("Connection broke!");

            Reconnect ();
        }

        private  void Reconnect() 
        {
            Cleanup ();

            var mres = new ManualResetEventSlim (false); // state is initially false

            while (!mres.Wait (3000)) // loop until state is true, checking every 3s
            {
                try 
                {
                    Connect ();

                    Console.WriteLine ("Connected!");
                    mres.Set (); // state set to true - breaks out of loop
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine ("Connect failed!", ex);
                }
            }
        }
    }
}