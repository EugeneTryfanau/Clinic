using StandartCRUD;
using StandartCRUD.StandartBLL.Models;

namespace Services.BLL.Models
{
    public class Service : BaseModel
    {
        public required string ServiceName { get; set; }
        public decimal Price { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
