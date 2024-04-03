using Microsoft.Extensions.DependencyInjection;
using Services.BLL.Interfaces;
using Services.BLL.Services;

namespace Services.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        }
    }
}
