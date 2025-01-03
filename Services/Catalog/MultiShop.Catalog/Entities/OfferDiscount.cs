using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountId { get; set; }
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountImageUrl { get; set; }
        public string OfferDiscountButtonTitle { get; set; }
    }
}