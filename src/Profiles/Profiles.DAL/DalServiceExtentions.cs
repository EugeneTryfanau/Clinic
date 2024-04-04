using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profiles.DAL.Interfaces;
using Profiles.DAL.Repositories;

namespace Profiles.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProfilesDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProfilesDbConnection"), b => b.MigrationsAssembly("Profiles.DAL"));
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
        }
    }
}
