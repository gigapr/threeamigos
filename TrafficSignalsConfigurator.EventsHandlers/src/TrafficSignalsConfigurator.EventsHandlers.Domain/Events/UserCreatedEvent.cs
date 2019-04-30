using System;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain.Events
{
    public class UserCreatedEvent : TrafficSignalsConfigurator.EventsHandlers.Domain.Events.Event
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserCreatedEvent(string userId, string username, string email, string password) 
        {
            UserId = userId;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}