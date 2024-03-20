using Clinic.BLL.Interfaces;
using NSubstitute;

namespace Clinic.IntegrationTests.TestData.Services
{
    public class MockedServices
    {
        public static IRabbitMqProducerService MoqRabbitMqService()
        {
            var service = Substitute.For<IRabbitMqProducerService>();

            service.SendMessage(Arg.Any<object>());
            service.SendMessage(Arg.Any<string>());

            return service;
        }
    }
}
