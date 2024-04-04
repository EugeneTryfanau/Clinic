namespace Profiles.DAL.Entities
{
    public class DoctorEntity : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required DateTime CareerStartYear { get; set; }
        public DoctorStatus Status { get; set; }

        public Guid? AccountId { get; set; }
        public Guid? OfficeId { get; set; }

        public virtual AccountEntity? Account { get; set; }

        public virtual ICollection<DoctorSpecializationEntity>? Specializations { get; set; }
    }
}
