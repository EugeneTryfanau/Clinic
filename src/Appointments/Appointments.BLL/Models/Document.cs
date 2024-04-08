using StandartCRUD.StandartBLL.Models;

namespace Appointments.BLL.Models
{
    public class Document : BaseModel
    {
        public required string Url { get; set; }

        public Guid? ResultId { get; set; }
    }
}
