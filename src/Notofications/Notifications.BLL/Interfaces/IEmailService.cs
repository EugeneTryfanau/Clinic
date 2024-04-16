using Notifications.BLL.Models;

namespace Notifications.BLL.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMail(EmailModel mailModel, NotificationModel notificationModel, ICollection<string> recipients);
    }
}