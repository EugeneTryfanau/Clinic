namespace Clinic.DAL.Entities
{
    public class OfficeEntity: Entity
    {
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid PhotoId { get; set; }

        public virtual PhotoEntity? Photo { get; set; }

        public virtual ICollection<DoctorEntity>? Doctors { get; set; }
    }
}
