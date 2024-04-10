using Clinic.DAL.Interfaces;
using Clinic.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IOfficeRepository, OfficeRepository>();
        }
    }
}
