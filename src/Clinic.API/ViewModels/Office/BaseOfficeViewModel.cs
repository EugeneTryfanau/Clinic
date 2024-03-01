using Clinic.DAL.Entities;

namespace Clinic.API.ViewModels.Office;

public class BaseOfficeViewModel
{
    public string? Address { get; set; } = string.Empty;
    public string? RegistryPhoneNumber { get; set; } = string.Empty;
    public OfficeStatus IsActive { get; set; }
}
