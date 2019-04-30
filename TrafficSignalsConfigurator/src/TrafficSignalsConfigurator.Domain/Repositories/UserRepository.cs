using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using TrafficSignalsConfigurator.Domain;
using TrafficSignalsConfigurator.Domain.DTOs;

namespace TrafficSignalsConfigurator.Domain.Repositories
{
    public partial class UserRepository : IUserRepository
    {
        private const string CollectionName = "Users";
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<UserDto> _users;

        public UserRepository(string databaseName, string connectionString)
        {
            var client = new MongoClient(new MongoUrl(connectionString));

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

        public async Task<UserDto> GetByEmail(string email)
        {
            var result = (await _users.FindAsync(u => u.Email == email)).FirstOrDefault();
           
            return result;
        }

        public async Task Add(string userId, string username, string email, string password)
        {
            var userDto = new UserDto
            {
                Id = userId,
                Username = username,
                Email = email,
                Password = password
            };

            await _users.InsertOneAsync(userDto);
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(u => u.Id == id, Map(user));
        }

        public void Remove(User newUser)
        {
            _users.DeleteOne(u => u.Id == newUser.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(u => u.Id == id);
        }

        private static UserDto Map(User newUser)
        {
            return new UserDto
            {
                Id = newUser.Id,
                Email = newUser.Email,
                Password = newUser.HashedPassword,
                Username = newUser.Username
            };
        }

        private IMongoCollection<UserDto> GetCollection()
        {
            var users = _database.GetCollection<UserDto>(CollectionName);

            if (users == null)
            {
                _database.CreateCollection(CollectionName);

                users = _database.GetCollection<UserDto>(CollectionName);
            }

            return users;
        }
    }
}
