using System;

namespace TrafficSignalsConfigurator.Domain.Events
{
    internal class UsereCreatedEvent : Event
    {
        public UsereCreatedEvent(string userId, string username, string email, string password) : base(Constants.EventSourceId)
        {
            Data = new 
            {
                userId = userId,
                username = username,
                email = email,
                password = password
            };
        }
    }
}