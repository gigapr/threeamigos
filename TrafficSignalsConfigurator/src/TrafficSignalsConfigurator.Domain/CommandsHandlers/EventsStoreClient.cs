using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Event = TrafficSignalsConfigurator.Domain.Events.Event;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public class EventsStoreClient : IEventsStoreClient
    {
        private readonly HttpClient _httpClient;

        public EventsStoreClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task Publish(Event ev)
        {
            var data = new 
            {
                sourceId = ev.SourceId,
                type = ev.GetType().Name,
                data = JsonConvert.SerializeObject(ev.Data)
            };

            var response = await _httpClient.PostAsync("event", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}