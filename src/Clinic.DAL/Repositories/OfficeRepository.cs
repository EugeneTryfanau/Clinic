using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Clinic.DAL.Entities.EnumsEntity;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository : Repository<OfficeEntity>, IOfficeRepository
    {
        public OfficeRepository(ClinicDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, OfficeStatus? isActive, CancellationToken cancellationToken)
        {
            IQueryable<OfficeEntity> query = _dbContext.Offices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(address))
            {
                var firstNameLower = address.ToLower();
                query = query.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{address}%"));
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                query = query.Where(x => EF.Functions.Like(x.RegistryPhoneNumber, $"%{phoneNumber}%"));
            }

            if (isActive != null)
            {
                query = query.Where(x => x.IsActive == isActive);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
