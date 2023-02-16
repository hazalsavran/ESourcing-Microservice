using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcing.Products.Entities
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]// Id kolonunun uniq olmasını sağlar, bu objectId 24 karakterden oluşur
        public string Id { get; set; } //Mongoda Idyi Bson gösterebilemk için string tipinde Id tutuyoruz
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
