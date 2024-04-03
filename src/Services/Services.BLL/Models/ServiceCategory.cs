using StandartCRUD.StandartBLL.Models;

namespace Services.BLL.Models
{
    public class ServiceCategory : BaseModel
    {
        public required string CategoryName { get; set; }
        public DateTime TimeSlotSize { get; set; }
    }
}
