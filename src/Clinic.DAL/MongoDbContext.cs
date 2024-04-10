using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Volo.Abp.MongoDB;

namespace Clinic.DAL
{
    public class MongoDbContext(DbContextOptions options) : DbContext(options)
    {
        //private readonly IMongoDatabase _database;

        //protected MongoDbContext(IOptions<MongoConnectionSettings> options)
        //{
        //    var client = new MongoClient(options.Value.ConnectionURI);
        //    _database = client.GetDatabase(options.Value.Database);
        //}

        //public IMongoCollection<OfficeEntity> Offices => Collection<OfficeEntity>("offices");

        //public IMongoCollection<T> Collection<T>(string name)
        //{
        //    return _database.GetCollection<T>(name);
        //}

        //public IMongoCollection<T> GetCollection<T>(ReadPreference? readPreference = null)
        //{
        //    return _database.WithReadPreference(readPreference ?? ReadPreference.Primary).GetCollection<T>(GetCollectionName<T>());
        //}

        //protected static string? GetCollectionName<T>()
        //{
        //    return (typeof(T).GetCustomAttributes(typeof(MongoCollectionAttribute), inherit: true).FirstOrDefault() as MongoCollectionAttribute)?.CollectionName;
        //}
        public DbSet<OfficeEntity> Offices { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OfficeEntity>();
        }
    }
}
