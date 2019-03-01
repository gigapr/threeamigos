using MongoDB.Bson.Serialization.Attributes;

namespace TrafficSignalsConfigurator.Domain.DTOs
{
    public class UserDto
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
