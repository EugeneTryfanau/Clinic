using Appointments.BLL.Interfaces;
using Appointments.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Appointments.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IDocumentService, DocumentService>();
        }
    }
}
