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
            var mongoDBSettings = configuration.GetSection("MongoDB").Get<MongoConnectionSettings>();
            services.Configure<MongoConnectionSettings>(configuration.GetSection("MongoDB"));

            services.AddDbContext<MongoDbContext>(options => options.UseMongoDB(mongoDBSettings!.ConnectionURI ?? "", mongoDBSettings.DatabaseName ?? ""));

            services.AddScoped<IOfficeRepository, OfficeRepository>();
        }
    }
}
