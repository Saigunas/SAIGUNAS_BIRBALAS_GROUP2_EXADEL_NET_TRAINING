using MongoDB.Bson.Serialization.Attributes;

namespace Task13.Models
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AuditInfo AuditInfo { get; set; }
        public IEnumerable<string>? Features { get; set; }
    }
}
