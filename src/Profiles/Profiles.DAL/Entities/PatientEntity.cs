using StandartCRUD.StandartDAL.Entities;

namespace Profiles.DAL.Entities
{
    public class PatientEntity : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public bool IsLinkedToAccount { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid? AccountId { get; set; }

        public virtual AccountEntity? Account { get; set; }
    }
}
