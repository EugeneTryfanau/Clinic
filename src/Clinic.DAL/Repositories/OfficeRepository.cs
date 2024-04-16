using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using StandartCRUD;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository(MongoDbContext dbContext) : IOfficeRepository
    {

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            IEnumerable<OfficeEntity> offices = await GetAllAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(address))
            {
                var addressLower = address.ToLower();
                offices = offices.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{addressLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                offices = offices.Where(x => EF.Functions.Like(x.RegistryPhoneNumber, $"%{phoneNumber}%"));
            }

            if (isActive != null)
            {
                offices = offices.Where(x => x.IsActive == isActive);
            }

            return offices;
        }

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<OfficeEntity>();
            var filter = filterBuilder.Where(x =>  x.Id != Guid.Empty );

            return (await dbContext.Offices. FindAsync(filter, null, cancellationToken)).ToEnumerable(cancellationToken);

        }

        public async Task<OfficeEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<OfficeEntity>();
            var filter = filterBuilder.Where(x => x.Id == id);

            return await (await dbContext.Offices.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<OfficeEntity> AddAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await dbContext.Offices.InsertOneAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<OfficeEntity> UpdateAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<OfficeEntity>();
            var filter = filterBuilder.Where(x => x.Id == entity.Id);

            var updateBuilder = new UpdateDefinitionBuilder<OfficeEntity>();

            var updateDefinition = updateBuilder
                .Set(x => x.Id, entity.Id)
                .Set(x => x.Address, entity.Address)
                .Set(x => x.RegistryPhoneNumber, entity.RegistryPhoneNumber)
                .Set(x => x.IsActive, entity.IsActive)
                .Set(x => x.PhotoId, entity.PhotoId);
            await dbContext.Offices.UpdateOneAsync(filter, updateDefinition, null, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<OfficeEntity>();
            var filter = filterBuilder.Where(x => x.Id == entity.Id);

            await dbContext.Offices.DeleteOneAsync(filter, null, cancellationToken);
        }
    }
}
