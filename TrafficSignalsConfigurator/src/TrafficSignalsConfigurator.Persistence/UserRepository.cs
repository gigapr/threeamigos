using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace TrafficSignalsConfigurator.Persistence
{
    public class UserRepository : IUserRepository
    {
        private const string CollectionName = "Users";
        private IMongoDatabase _database;
        private IMongoCollection<User> _users;

        public UserRepository(string databaseName, string connectionstring)
        {
            var client = new MongoClient(new MongoUrl(connectionstring));

            _database = client.GetDatabase(databaseName);
        
            _users = GetCollection();
        }

        public async Task<bool> IsEmailUnique(string email) 
        {
            var count = await _users.Find(u => u.Email == email).CountDocumentsAsync();
            
            return count == 0;
        }   

        public async Task<bool> IsUsernameUnique(string username) 
        {
            var count = await _users.Find(u => u.Username == username).CountDocumentsAsync();
            
            return count == 0;
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

        private IMongoCollection<User> GetCollection()
        {
            var users = _database.GetCollection<User>(CollectionName);

            if (users == null)
            {
                _database.CreateCollection(CollectionName);
                
                users = _database.GetCollection<User>(CollectionName);
            }

            return users;
        }
    }
}
