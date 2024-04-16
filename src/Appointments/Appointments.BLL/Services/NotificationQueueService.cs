using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;

namespace Appointments.BLL.Services
{
    public class NotificationQueueService : INotificationQueueService
    {
        private readonly Queue<Appointment> _queue = new Queue<Appointment>();

        public void Enqueue(Appointment appointment)
        {
            _queue.Enqueue(appointment);
        }

        public Appointment? CheckAndRelease()
        {
            while (_queue.Count > 0 && _queue.Peek().Date.AddDays(-1) <= DateTime.Now)
            {
                var releasedObject = _queue.Dequeue();
                if (releasedObject != null)
                {
                    return releasedObject;
                }
            }
            return null;
        }
    }
}
