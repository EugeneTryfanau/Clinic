namespace Notifications.BLL.Models
{
    internal class NotificationOfficeModel
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string? RegistryPhoneNumber { get; set; }
        public StandartStatus IsActive { get; set; }
    }
}
