using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrafficSignalsConfigurator.Persistence
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }
        
        [BsonElement("Email")]
        public string Email { get; set; }
        
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
