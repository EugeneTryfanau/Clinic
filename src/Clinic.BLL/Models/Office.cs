using Clinic.DAL.Entities;

namespace Clinic.BLL.Models
{
    public class Office : BaseModel
    {
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public OfficeStatus IsActive { get; set; }
    }
}
