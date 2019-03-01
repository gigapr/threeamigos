using CryptoHelper;

namespace TrafficSignalsConfigurator.Domain
{
    public class User
    {
        public string Id { get; }

        public string Username { get; }
        
        public string Email { get; }
        
        public string HashedPassword { get; }

        public User(string id, string username, string email, string hashedPassword)
        {
            Id = id;
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
        }

        public bool IsOwnPassword(string password)
        {
            return Crypto.VerifyHashedPassword(HashedPassword, password);
        }
    }
}