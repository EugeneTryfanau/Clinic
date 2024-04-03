using StandartCRUD;

namespace Profiles.API.ViewModels
{
    public record ProfileSearchRequestData(string? Name, string? Email, string? PhoneNumber, bool? IsActiveAccount, DoctorStatus? DoctorStatus);
}
