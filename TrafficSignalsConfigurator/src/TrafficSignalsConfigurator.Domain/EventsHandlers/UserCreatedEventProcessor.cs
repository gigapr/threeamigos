using System.Threading.Tasks;
using TrafficSignalsConfigurator.Domain.Events;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.EventsHandlers
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