using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;
using TrafficSignalsConfigurator.Domain;
using TrafficSignalsConfigurator.Domain.Queries;
using TrafficSignalsConfigurator.Domain.Repositories;
using TrafficSignalsConfigurator.Domain.DTOs;

namespace TrafficSignalsConfigurator.Domain.QueriesHandlers
{
    public class GetUserQueryHandler : QueryHandlerAsync<GetUserQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public override async Task<User> ExecuteAsync(GetUserQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var userDto = await _repository.GetByEmail(query.Email);

            if (userDto != null)
            {
                return Map(userDto);
            }

            return null;
        }

        private static User Map(UserDto userDto)
        {
            return new User(userDto.Id, userDto.Username, userDto.Email, userDto.Password);
        }
    }
}
