using Clinic.BLL.Interfaces;
using Clinic.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.BLL
{
    public static class BllServiceExtensions
    {
        public static void AddBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IRabbitMqProducerService, RabbitMqProducerService>();
        }
    }
}
