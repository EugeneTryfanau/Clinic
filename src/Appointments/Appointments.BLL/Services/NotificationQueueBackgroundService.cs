using Appointments.BLL.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Appointments.BLL.Services
{
    public class NotificationQueueBackgroundService(INotificationQueueService queueService, IRabbitMqProducerService rabbitMqProducerService) : BackgroundService
    {
        private readonly INotificationQueueService _queueService = queueService;
        private readonly IRabbitMqProducerService _rabbitService = rabbitMqProducerService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var appointment = _queueService.CheckAndRelease();

                if(appointment == null)
                {
                    _rabbitService.SendMessage(appointment!);
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
