using StandartCRUD.StandartBLL.Models;

namespace Appointments.BLL.Models
{
    public class Result : BaseModel
    {
        public required string Complaints { get; set; }
        public required string Conclusion { get; set; }
        public string? Recomendations { get; set; }

        public Guid? AppointmentId { get; set; }
    }
}
