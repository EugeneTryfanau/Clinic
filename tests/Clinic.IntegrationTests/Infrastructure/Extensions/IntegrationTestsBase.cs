using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Clinic.IntegrationTests.TestData.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Clinic.IntegrationTests.Infrastructure.Extensions
{
    public class IntegrationTestsBase : IDisposable
    {
        public IntegrationTestsBase()
        {
            Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            builder.ConfigureServices(services =>
            {
                var descriptorMongo = services.SingleOrDefault(d => d.ServiceType == typeof(IMongoCollection<OfficeEntity>));
                var descriptorRepo = services.SingleOrDefault(d => d.ServiceType == typeof(IOfficeRepository));

                if (descriptorMongo != null)
                    services.Remove(descriptorMongo);
                if (descriptorRepo != null)
                    services.Remove(descriptorRepo);

                services.AddScoped<IOfficeRepository, MockOfficeRepository>();

                services.AddSingleton(provider =>
                {
                    var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
                    var client = new MongoClient(settings);
                    var database = client.GetDatabase("TestDb");
                    return database.GetCollection<OfficeEntity>("TestCollection");
                });

                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, MockedAuth>("Test", options => { });
            }));
            Server = Factory.Server;
            Client = Factory.CreateClient();
            OfficeCollection = Factory.Services.GetRequiredService<IMongoCollection<OfficeEntity>>();
        }

        protected TestServer Server { get; }
        protected HttpClient Client { get; }
        protected IMongoCollection<OfficeEntity> OfficeCollection { get; private set; }
        private WebApplicationFactory<Program> Factory { get; }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}
