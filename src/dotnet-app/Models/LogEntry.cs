using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DevOpsApp.Models
{
    public class LogEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("message")]
        public string? Message { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
