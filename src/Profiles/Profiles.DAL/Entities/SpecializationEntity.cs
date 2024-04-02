namespace Profiles.DAL.Entities
{
    public class SpecializationEntity
    {
        public required string SpecializationName { get; set; }
        public StandartStatus IsActive { get; set; }

        public virtual ICollection<DoctorSpecializationEntity>? Doctors { get; set; }
    }
}
