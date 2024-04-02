using Profiles.DAL.Entities;

namespace Profiles.API.ViewModels.Specialization
{
    public class BaseSpecializationViewModel
    {
        public string? SpecializationName { get; set; } = string.Empty;
        public StandartStatus IsActive { get; set; }
    }
}
