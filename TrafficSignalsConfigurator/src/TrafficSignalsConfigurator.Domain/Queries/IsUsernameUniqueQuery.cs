using Paramore.Darker;
using System;

namespace TrafficSignalsConfigurator.Domain.Queries
{
    public class IsUsernameUniqueQuery: IQuery<bool>
    {
        public string Username { get; }

        public IsUsernameUniqueQuery(string username)
        {
            if(string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            
            Username = username;
        }
    }
}