using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string AboutDescription { get; set; }
        public string AboutAddress { get; set; }
        public string AboutEmail { get; set; }
        public string AboutPhone { get; set; }
    }
}
