using Clinic.BLL.Interfaces;
using Clinic.DAL;
using Clinic.DAL.Entities;
using Clinic.IntegrationTests.TestData.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StandartCRUD.StandartDAL.Entities;

namespace Clinic.IntegrationTests.Infrastructure.Extensions
{
    public class IntegrationTestsBase : IDisposable
    {
        public IntegrationTestsBase()
        {
            Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            builder.ConfigureServices(services =>
            {
                var dbContextService = services.SingleOrDefault(x =>
                    x.ServiceType == typeof(DbContextOptions<ClinicDbContext>));
                services.Remove(dbContextService!);

                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, MockedAuth>("Test", options => { });

                services.AddDbContext<ClinicDbContext>(options => options.UseInMemoryDatabase("TestDb"));
                services.RemoveAll<IRabbitMqProducerService>();
                services.AddScoped(_ => MockedServices.MoqRabbitMqService());
            }));
            Server = Factory.Server;
            Client = Factory.CreateClient();
            Context = Factory.Services.CreateScope().ServiceProvider.GetService<ClinicDbContext>()!;
        }

        protected TestServer Server { get; }
        protected HttpClient Client { get; }
        protected ClinicDbContext Context { get; }
        private WebApplicationFactory<Program> Factory { get; }

        public async Task<Guid> AddToContext<T>(T entity) where T : Entity
        {
            var dbSet = Context.Set<T>();
            await dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
