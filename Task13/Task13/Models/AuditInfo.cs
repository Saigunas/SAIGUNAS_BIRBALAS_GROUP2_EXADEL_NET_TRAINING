using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace Task13.Models
{
    public class AuditInfo
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        [DefaultValue(1)]
        public int Version { get; set; } = 1;
    }
}
