using StandartCRUD;

namespace Profiles.DAL.Entities
{
    public class AccountEntity : Entity
    {
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid? PhotoId { get; set; }
    }
}
