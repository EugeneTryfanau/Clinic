using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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

        private IConnection _connection;
        private IModel _channel;

        private readonly string _host;
        private readonly string _queue;

        public RabbitMqListenerService(IConfiguration configuration, IEmailService emailService)
        {
            _emailService = emailService;

            _host = configuration["RabbitMq:RabbitMqHost"]!;
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

                _emailService.SendMail(new EmailModel() { EmailBody=content, EmailSubject="Произошло удаление again" }, new List<string>() { "eugenetryfanau@gmail.com", "nomand144@gmail.com" });

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