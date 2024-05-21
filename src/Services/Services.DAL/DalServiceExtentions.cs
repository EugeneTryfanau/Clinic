using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.DAL.Interfaces;
using Services.DAL.Repositories;

namespace Services.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServicesDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ServiceDbConnection"), b => b.MigrationsAssembly("Services.DAL"));
            });

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        }
    }
}
