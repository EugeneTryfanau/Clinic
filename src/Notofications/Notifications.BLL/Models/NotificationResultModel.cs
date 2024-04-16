namespace Notifications.BLL.Models
{
    public class NotificationResultModel : NotificationModel
    {
        public required string Complaints { get; set; }
        public required string Conclusion { get; set; }
        public string? Recomendations { get; set; }

        public Guid? AppointmentId { get; set; }
    }
}
