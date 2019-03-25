using System;

namespace TrafficSignalsConfigurator.Domain.Events
{
    public class Event 
    {
    }

    public class UserCreatedEvent : Event
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