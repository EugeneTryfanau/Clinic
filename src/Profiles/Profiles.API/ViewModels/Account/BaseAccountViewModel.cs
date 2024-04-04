namespace Profiles.API.ViewModels.Account
{
    public class BaseAccountViewModel
    {
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }

        public Guid? PhotoId { get; set; } = Guid.Empty;
    }
}
