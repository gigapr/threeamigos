using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using TrafficSignalsConfigurator.Domain.Queries;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.QueriesHandlers
{
    public class IsEmailUniqueQueryHandler : QueryHandlerAsync<IsEmailUniqueQuery, bool>
    {
        private readonly IUserRepository _repository;

        public IsEmailUniqueQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public override Task<bool> ExecuteAsync(IsEmailUniqueQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return _repository.IsEmailUnique(query.Email);
        }
    }
}