using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HepsiYemekCore.Core.Entities
{
    public interface IBaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
        [BsonElement("Description")]
        string Description { get; set; }
        [BsonElement("Name")]
        string Name { get; set; }
    }
}
