using Clinic.DAL.Interfaces;
using Clinic.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoConnectionSettings>(configuration.GetSection("MongoDB"));

            services.AddTransient<MongoDbContext>();

            services.AddScoped<IOfficeRepository, OfficeRepository>();
        }
    }
}
