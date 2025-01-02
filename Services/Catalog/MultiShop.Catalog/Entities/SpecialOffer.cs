using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string SpecialOfferTitle { get; set; }
        public string SpecialOfferSubTitle { get; set; }
        public string SpecialOfferImageUrl { get; set; }
    }
}
