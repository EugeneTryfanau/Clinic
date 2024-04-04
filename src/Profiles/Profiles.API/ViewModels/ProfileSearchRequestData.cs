using Profiles.DAL.Entities;

namespace Profiles.API.ViewModels
{
    public record ProfileSearchRequestData(string? Name, string? Email, string? PhoneNumber, bool? IsActiveAccount, DoctorStatus? DoctorStatus);
}
