using Microsoft.Extensions.DependencyInjection;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Services;

namespace Profiles.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IReceptionistService, ReceptionistService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
        }
    }
}
