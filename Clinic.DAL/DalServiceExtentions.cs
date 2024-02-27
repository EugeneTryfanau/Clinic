using Clinic.DAL.Interfaces;
using Clinic.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Clinic.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("Clinic.DAL"));
            });

            services.AddScoped<IOfficeRepository, OfficeRepository>();
        }
    }
}
