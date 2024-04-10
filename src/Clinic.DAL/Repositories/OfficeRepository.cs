using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using StandartCRUD;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository(MongoDbContext dbContext) : IOfficeRepository
    {
        private readonly MongoDbContext _dbContext = dbContext;

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            IEnumerable<OfficeEntity> officeEntities = await _dbContext.Offices.ToListAsync(cancellationToken);

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
            return await _dbContext.Offices.ToListAsync(cancellationToken);
        }

        public async Task<OfficeEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Offices.Where(of => of.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<OfficeEntity> AddAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await _dbContext.Offices.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<OfficeEntity> UpdateAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            var office = await _dbContext.Offices.FirstOrDefaultAsync(of => of.Id == entity.Id, cancellationToken);

            if (office != null)
            {
                office.Address = entity.Address;
                office.IsActive = entity.IsActive;
                office.RegistryPhoneNumber = entity.RegistryPhoneNumber;
                office.PhotoId = entity.PhotoId;

                _dbContext.Offices.Update(office);

                _dbContext.ChangeTracker.DetectChanges();
                _dbContext.SaveChanges();
                return office.As<OfficeEntity>();
            }
            else
            {
                throw new ArgumentException("Wrong ID");
            }
        }

        public async Task DeleteAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            var office = await _dbContext.Offices.FirstOrDefaultAsync(of => of.Id == entity.Id, cancellationToken);
            if (office != null)
            {
                _dbContext.Offices.RemoveRange(office);
            }
            else
            {
                throw new ArgumentException("Etity not found");
            }
        }
    }
}
