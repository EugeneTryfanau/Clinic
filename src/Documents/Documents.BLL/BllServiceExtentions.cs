using Documents.BLL.Interfaces;
using Documents.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Documents.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
        }
    }
}
