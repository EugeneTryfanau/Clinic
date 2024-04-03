using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Repositories
{
    public class SpecializationRepository(ProfilesDbContext dbContext) : 
        Repository<SpecializationEntity, ProfilesDbContext>(dbContext), 
        ISpecializationRepository
    {
        public async Task<IEnumerable<SpecializationEntity>> GetAllAsync(string? specName, CancellationToken cancellationToken)
        {
            IQueryable<SpecializationEntity> query = _dbContext.Specializations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(specName))
            {
                var nameLower = specName.ToLower();
                query = query.Where(x => EF.Functions.Like(x.SpecializationName.ToLower(), $"%{nameLower}%"));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
