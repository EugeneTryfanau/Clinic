using Clinic.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Clinic.BLL.Services
{
    public class RabbitMqProducerService : IRabbitMqProducerService
    {
        private readonly string _host;
        private readonly string _queue;

        public RabbitMqProducerService(IConfiguration configuration)
        {
            _host = configuration["RabbitMq:RabbitMqHost"]!;
            _queue = configuration["RabbitMq:RabbitMqQueue"]!;
        }

        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = _host };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queue,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: _queue,
                               basicProperties: null,
                               body: body);
            }
        }
    }
}
