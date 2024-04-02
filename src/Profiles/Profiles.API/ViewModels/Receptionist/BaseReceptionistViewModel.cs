namespace Profiles.API.ViewModels.Receptionist
{
    public class BaseReceptionistViewModel
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;

        public Guid? AccountId { get; set; } = Guid.Empty;
        public Guid? OfficeId { get; set; } = Guid.Empty;
    }
}
