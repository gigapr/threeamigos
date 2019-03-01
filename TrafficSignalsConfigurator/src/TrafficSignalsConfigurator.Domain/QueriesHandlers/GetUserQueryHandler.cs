using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using TrafficSignalsConfigurator.Domain;
using TrafficSignalsConfigurator.Domain.Queries;
using TrafficSignalsConfigurator.Domain.Repositories;

namespace TrafficSignalsConfigurator.Domain.QueriesHandlers
{
    public class GetUserQueryHandler : QueryHandlerAsync<GetUserQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public override Task<User> ExecuteAsync(GetUserQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return _repository.GetByEmail(query.Email);
        }
    }
}
