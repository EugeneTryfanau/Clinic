using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using StandartCRUD;
using StandartCRUD.StandartDAL.Entities;

namespace Clinic.DAL.Entities
{
    [Collection("offices")]
    public class OfficeEntity : Entity
    {
        [BsonElement("address")]
        public required string Address { get; set; } = null!;

        [BsonElement("registryPhoneNumber")]
        public required string RegistryPhoneNumber { get; set; } = null!;

        [BsonElement("isActive")]
        public StandartStatus IsActive { get; set; }

        [BsonElement("photoId")]
        public Guid? PhotoId { get; set; }
    }
}
