using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using TrafficSignalsConfigurator.Domain.Queries;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.QueriesHandlers
{
    public class IsUsernameUniqueQueryHandler : QueryHandlerAsync<IsUsernameUniqueQuery, bool>
    {
        private readonly IUserRepository _repository;

        public IsUsernameUniqueQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public override Task<bool> ExecuteAsync(IsUsernameUniqueQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return _repository.IsUsernameUnique(query.Username);
        }
    }
}