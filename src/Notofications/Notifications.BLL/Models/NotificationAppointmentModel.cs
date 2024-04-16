namespace Notifications.BLL.Models
{
    internal class NotificationAppointmentModel : NotificationModel
    {
        public required DateTime Date { get; set; }
        public required DateTime Time { get; set; }
        public required bool IsApproved { get; set; }

        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
