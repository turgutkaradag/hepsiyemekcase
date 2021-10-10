using HepsiYemekCore.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HepsiYemekCore.Core
{
    public class Products : IBaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }
}
