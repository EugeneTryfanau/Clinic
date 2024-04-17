using Azure.Storage.Blobs;
using Documents.BLL.Interfaces;
using Documents.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Documents.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPdfGeneratorService, PdfGeneratorService>();
            services.AddSingleton(x => new BlobServiceClient(configuration.GetSection("AzureConfig:AzureBlobStorage").Value));
            services.AddSingleton<AzureBlobService>();
        }
    }
}
