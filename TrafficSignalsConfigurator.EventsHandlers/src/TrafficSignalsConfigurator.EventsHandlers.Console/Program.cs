using System;
using TrafficSignalsConfigurator.EventsHandlers.Domain;
using Microsoft.Extensions.Configuration;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Repositories;

namespace TrafficSignalsConfigurator.EventsHandlers.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var Configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

            var RabbitMqConnectionstring = Configuration["RabbitMqConnectionstring"];
            var databaseName = "TrafficSignalsConfigurator";
            var databaseConnectionString = Configuration.GetConnectionString("TrafficSignalsConfiguratorDb");

            var userRepository = new UserRepository(databaseName, databaseConnectionString);
            var userCreatedEventprocessor = new UserCreatedEventProcessor(userRepository);
            var eventSubscriber = new UserCreatedEventSubscriber(RabbitMqConnectionstring, userCreatedEventprocessor);

            System.Console.WriteLine("Started TrafficSignalsConfigurator.EventsHandlers");

            
        }
    }
}
