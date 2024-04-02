using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.DAL.Repositories
{
    public class DoctorRepository(ProfilesDbContext dbContext) : 
        Repository<DoctorEntity>(dbContext), 
        IDoctorRepository
    {
        public async Task<IEnumerable<DoctorEntity>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken)
        {
            IQueryable<DoctorEntity> query = _dbContext.Doctors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like((x.MiddleName + x.LastName + x.FirstName).ToLower(), $"%{nameLower}%"));
            }

            if (status != null)
            {
                query = query.Where(x => x.Status == status);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}