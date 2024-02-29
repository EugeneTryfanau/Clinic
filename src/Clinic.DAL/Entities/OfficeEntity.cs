using static Clinic.DAL.Entities.EnumsEntity;

namespace Clinic.DAL.Entities
{
    public class OfficeEntity: Entity
    {
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public OfficeStatus IsActive { get; set; }
    }
}
