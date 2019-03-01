using Paramore.Darker;
using System;

namespace TrafficSignalsConfigurator.Domain.Queries
{
    public class IsEmailUniqueQuery: IQuery<bool>
    {
        public string Email { get; }

        public IsEmailUniqueQuery(string email)
        {
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            
            Email = email;
        }
    }
}