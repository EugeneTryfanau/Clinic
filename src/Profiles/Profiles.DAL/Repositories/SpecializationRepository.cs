using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.DAL.Repositories
{
    public class SpecializationRepository : Repository<SpecializationEntity>, ISpecializationRepository
    {
        public SpecializationRepository(ProfilesDbContext dbContext) : base(dbContext) { }

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
