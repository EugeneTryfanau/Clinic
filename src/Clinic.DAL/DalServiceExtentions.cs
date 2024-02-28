using Clinic.DAL.Interfaces;
using Clinic.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Clinic.DAL"));
            });

            services.AddScoped<IOfficeRepository, OfficeRepository>();
        }
    }
}
