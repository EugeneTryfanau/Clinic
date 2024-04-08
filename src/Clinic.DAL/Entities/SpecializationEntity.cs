using StandartCRUD;
using StandartCRUD.StandartDAL.Entities;

namespace Clinic.DAL.Entities
{
    public class SpecializationEntity : Entity
    {
        public required string SpecializationName { get; set; }
        public StandartStatus IsActive { get; set; }

        public virtual ICollection<DoctorSpecializationEntity>? Doctors { get; set; }
    }
}
