using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace TrafficSignalsConfigurator.Persistence
{
    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> _users;

        public UserRepository(string databaseName, string connectionstring)
        {            
            var client = new MongoClient(connectionstring);
            
            var database = client.GetDatabase(databaseName);
            
            _users = database.GetCollection<User>("Users");
        }
        public async Task<bool> IsEmailUnique(string email) 
        {
            var result = await _users.FindAsync(u => u.Email == email);

            return result.Current == null;
        }

        public async Task<bool> IsUsernameUniqueAsync(string username) 
        {
            var result = await _users.FindAsync(u => u.Username == username);
            
            return result.Current == null;
        }

        public User Get(Expression<Func<User, bool>> predicate)
        {
            return _users.Find<User>(predicate).FirstOrDefault();
        }

        public User Add(User user)
        {
            _users.InsertOne(user);

            return user;
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(u => u.Id == id, user);
        }

        public void Remove(User user)
        {
            _users.DeleteOne(u => u.Id == user.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(u => u.Id == id);
        }
    }
}
