using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Paramore.Brighter;
using TrafficSignalsConfigurator.Domain.Commands;
using TrafficSignalsConfigurator.Domain.Events;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public class CreateUserCommandHandler : RequestHandlerAsync<CreateUserCommand> 
    {
        private readonly IEventsStoreClient _eventsStoreClient;

        public CreateUserCommandHandler (IEventsStoreClient eventsStoreClient) 
        {
            _eventsStoreClient = eventsStoreClient;
        }

        public override async Task<CreateUserCommand> HandleAsync (CreateUserCommand command, CancellationToken cancellationToken = default (CancellationToken)) 
        {
            var userCreatedEvent = new UserCreatedEvent(command.UserId, command.Username, command.Email, command.Password);

            await _eventsStoreClient.Publish(new EventStoreMessage(Constants.EventSourceId, userCreatedEvent, userCreatedEvent.GetType().Name));

            return await base.HandleAsync(command, cancellationToken).ConfigureAwait(base.ContinueOnCapturedContext);
        }
    }
}