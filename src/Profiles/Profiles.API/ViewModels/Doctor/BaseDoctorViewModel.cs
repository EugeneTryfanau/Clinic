using StandartCRUD;

namespace Profiles.API.ViewModels.Doctor
{
    public class BaseDoctorViewModel
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public required DateTime DateOfBirth { get; set; }
        public required DateTime CareerStartYear { get; set; }
        public DoctorStatus Status { get; set; }

        public Guid? AccountId { get; set; } = Guid.Empty;
        public Guid? OfficeId { get; set; } = Guid.Empty;
    }
}
