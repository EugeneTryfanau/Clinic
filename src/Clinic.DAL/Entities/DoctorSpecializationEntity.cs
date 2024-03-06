namespace Clinic.DAL.Entities
{
    public class DoctorSpecializationEntity
    {
        public Guid DoctorId { get; set; }
        public DoctorEntity? Doctor { get; set; }

        public Guid SpecificationId { get; set; }
        public SpecializationEntity? Specification { get; set; }
    }
}
