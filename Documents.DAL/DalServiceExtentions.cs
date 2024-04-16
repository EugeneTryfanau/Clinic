using Microsoft.EntityFrameworkCore;
using Documents.DAL.Interfaces;
using Documents.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Documents.DAL
{
    public static class DalServiceExtentions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DocumentsDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DocumentsDbConnection"), b => b.MigrationsAssembly("Documents.DAL"));
            });

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
        }
    }
}
