using StandartCRUD;
using StandartCRUD.StandartBLL.Models;

namespace Clinic.BLL.Models
{
    public class Office : BaseModel
    {
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public StandartStatus IsActive { get; set; }
    }
}
