using System;

namespace TrafficSignalsConfigurator.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string email) : base($"User with email: '{email}' cannot be found.")
        {
            
        }
    }
}