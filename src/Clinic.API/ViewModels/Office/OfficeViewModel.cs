using Clinic.DAL.Entities;

namespace Clinic.API.ViewModels.Office
{
    public class OfficeViewModel
    {
        public Guid Id { get; set; }
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public OfficeStatus IsActive { get; set; }
    }
}
