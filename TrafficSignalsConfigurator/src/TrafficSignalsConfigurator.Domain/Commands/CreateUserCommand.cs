using System;
using CryptoHelper;
using Paramore.Brighter;

namespace TrafficSignalsConfigurator.Domain.Commands
{
    public class CreateUserCommand : Command
    {
        public string UserId { get; }
        public string Username { get; }
        public string Email{ get; }
        public string Password{ get; }

        public CreateUserCommand(string username, string email, string password) : base(Guid.NewGuid())
        {
            if(string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            if(string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
            
            Id = Guid.NewGuid();

            UserId = Guid.NewGuid().ToString();
            Username = username;
            Email = email;
            Password = Crypto.HashPassword(password);
        }
    }
}
