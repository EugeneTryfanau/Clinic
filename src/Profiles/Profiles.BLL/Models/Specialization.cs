using StandartCRUD;
using StandartCRUD.StandartBLL.Models;

namespace Profiles.BLL.Models
{
    public class Specialization : BaseModel
    {
        public required string SpecializationName { get; set; }
        public StandartStatus IsActive { get; set; }
    }
}
