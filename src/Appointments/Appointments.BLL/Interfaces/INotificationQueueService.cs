using Appointments.BLL.Models;

namespace Appointments.BLL.Interfaces
{
    public interface INotificationQueueService
    {
        void Enqueue(Appointment appointment);
        Appointment? CheckAndRelease();
    }
}
