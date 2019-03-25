using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrafficSignalsConfigurator.Domain.Events;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public class EventsStoreClient : IEventsStoreClient
    {
        private readonly HttpClient _httpClient;

        public EventsStoreClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task Publish(EventStoreMessage eventStoreMessage)
        {
            var json = JsonConvert.SerializeObject(eventStoreMessage);

            var response = await _httpClient.PostAsync("event", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}