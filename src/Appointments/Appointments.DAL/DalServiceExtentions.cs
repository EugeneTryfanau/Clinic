using Appointments.DAL.Interfaces;
using Appointments.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appointments.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection") + configuration["Secrets:PostgreSQLPass"], b => b.MigrationsAssembly("Appointments.DAL"));
            });

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
        }
    }
}
