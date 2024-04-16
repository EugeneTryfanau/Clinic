using StandartCRUD;

namespace Clinic.API.ViewModels.Office;

public class OfficeViewModel
{
    public Guid Id { get; set; }
    public string? Address { get; set; } = string.Empty;
    public string? RegistryPhoneNumber { get; set; } = string.Empty;
    public StandartStatus IsActive { get; set; }
}
