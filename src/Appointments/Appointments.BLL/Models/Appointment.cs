using StandartCRUD.StandartBLL.Models;

namespace Appointments.BLL.Models
{
    public class Appointment : BaseModel
    {
        public required DateTime Date { get; set; }
        public required DateTime Time { get; set; }
        public required bool IsApproved { get; set; }

        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
