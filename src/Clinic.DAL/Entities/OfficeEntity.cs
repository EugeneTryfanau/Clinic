using MongoDB.Bson.Serialization.Attributes;
using StandartCRUD;
using StandartCRUD.StandartDAL.Entities;

namespace Clinic.DAL.Entities
{
    public class OfficeEntity : Entity
    {
        [BsonElement("address")]
        [BsonRequired]
        public required string Address { get; set; } = null!;

        [BsonElement("registryPhoneNumber")]
        [BsonRequired]
        public required string RegistryPhoneNumber { get; set; } = null!;

        [BsonElement("isActive")]
        public StandartStatus IsActive { get; set; }

        [BsonElement("photoId")]
        public Guid? PhotoId { get; set; }
    }
}
