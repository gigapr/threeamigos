using Paramore.Darker;
using TrafficSignalsConfigurator.Domain;
using System;

namespace TrafficSignalsConfigurator.Domain.Queries
{
    public class GetUserQuery: IQuery<User>
    {
        public string Email { get; }

        public GetUserQuery(string email)
        {
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
