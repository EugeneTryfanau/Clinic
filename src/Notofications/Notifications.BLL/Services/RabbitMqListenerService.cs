using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Notifications.BLL.Interfaces;
using Notifications.BLL.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Notifications.BLL.Services
{
    public class RabbitMqListenerService : BackgroundService
    {
        private readonly IEmailService _emailService;

        private readonly IConnection _connection;
        private readonly IModel _channel;

        private readonly string _queue;

        public RabbitMqListenerService(IConfiguration configuration, IEmailService emailService)
        {
            _emailService = emailService;

            var _host = configuration["RabbitMq:RabbitMqHost"]!;
            _queue = configuration["RabbitMq:RabbitMqQueue"]!;

            var factory = new ConnectionFactory { HostName = _host };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var messageType = ea.BasicProperties.Headers["MessageType"].ToString();

                switch (messageType)
                {
                    case "Appointment":
                        var appointment = JsonConvert.DeserializeObject<NotificationAppointmentModel>(content)!;
                        appointment.Type = "Appointment";
                        _emailService.SendMail(new EmailModel() { EmailBody = content, EmailSubject = $"Hello, you have appointnemt tomorrow {appointment.Date.Date} " +
                                $"at {appointment.Time.TimeOfDay}" }, appointment, ["eugenetryfanau@gmail.com", "nomand144@gmail.com"]);
                        break;
                    case "Result":
                        var result = JsonConvert.DeserializeObject<NotificationResultModel>(content)!;
                        result.Type = "Result";
                        _emailService.SendMail(new EmailModel() { EmailBody = content, EmailSubject = $"Hello, your appointment results" }, result,
                            ["eugenetryfanau@gmail.com", "nomand144@gmail.com"]);
                        break;
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queue, false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}