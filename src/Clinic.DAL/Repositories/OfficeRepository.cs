using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StandartCRUD;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IMongoCollection<OfficeEntity> _officeCollection;

        public OfficeRepository(IOptions<MongoDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionURI);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _officeCollection = mongoDatabase.GetCollection<OfficeEntity>(
                databaseSettings.Value.CollectionName);
        }

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            IEnumerable<OfficeEntity> officeEntities = await _officeCollection.Find(_ => true).ToListAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(address))
            {
                var addressLower = address.ToLower();
                officeEntities = officeEntities.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{addressLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                officeEntities = officeEntities.Where(x => EF.Functions.Like(x.RegistryPhoneNumber, $"%{phoneNumber}%"));
            }

            if (isActive != null)
            {
                officeEntities = officeEntities.Where(x => x.IsActive == isActive);
            }

            return officeEntities;
        }

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _officeCollection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<OfficeEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _officeCollection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<OfficeEntity> AddAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await _officeCollection.InsertOneAsync(entity, null, cancellationToken);
            return entity;
        }

        public async Task<OfficeEntity> UpdateAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await _officeCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return entity;
        }

        public async Task DeleteAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await _officeCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }
    }
}
