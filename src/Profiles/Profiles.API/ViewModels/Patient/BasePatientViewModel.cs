namespace Profiles.API.ViewModels.Patient
{
    public class BasePatientViewModel
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public bool IsLinkedToAccount { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid? AccountId { get; set; } = Guid.Empty;
    }
}
