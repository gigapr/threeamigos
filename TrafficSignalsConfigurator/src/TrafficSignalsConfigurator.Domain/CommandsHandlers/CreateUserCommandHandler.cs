using System.Threading;
using System.Threading.Tasks;
using Paramore.Brighter;
using TrafficSignalsConfigurator.Domain.Commands;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.CommandsHandlers
{
    public class CreateUserCommandHandler : RequestHandlerAsync<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public override async Task<CreateUserCommand> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _repository.Add(command.UserId, command.Username, command.Email, command.Password);

            return await base.HandleAsync(command, cancellationToken).ConfigureAwait(base.ContinueOnCapturedContext);
        }
    }
}
