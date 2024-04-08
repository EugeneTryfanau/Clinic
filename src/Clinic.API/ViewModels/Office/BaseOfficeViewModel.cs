using StandartCRUD;

namespace Clinic.API.ViewModels.Office;

public class BaseOfficeViewModel
{
    public string? Address { get; set; } = string.Empty;
    public string? RegistryPhoneNumber { get; set; } = string.Empty;
    public StandartStatus IsActive { get; set; }
}
