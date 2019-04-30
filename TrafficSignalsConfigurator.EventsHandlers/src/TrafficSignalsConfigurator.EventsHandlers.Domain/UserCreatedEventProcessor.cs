using System.Threading.Tasks;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Events;
using TrafficSignalsConfigurator.EventsHandlers.Domain.Repositories;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain
{
    public class UserCreatedEventProcessor : IEventProcessor<UserCreatedEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserCreatedEventProcessor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ProcessAsync(UserCreatedEvent @event)
        {
             await _userRepository.Add(@event.UserId, @event.Username, @event.Email, @event.Password);
        }
    }
}