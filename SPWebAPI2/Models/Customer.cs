using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SPWebAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CustomerMessage { get; set; }

    }
}
