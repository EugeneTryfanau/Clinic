using StandartCRUD;

namespace Profiles.BLL.Models
{
    public class Specialization : BaseModel
    {
        public required string SpecializationName { get; set; }
        public StandartStatus IsActive { get; set; }
    }
}
