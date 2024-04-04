using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Repositories
{
    public class ReceptionistRepository(ProfilesDbContext dbContext) : 
        Repository<ReceptionistEntity, ProfilesDbContext>(dbContext), 
        IReceptionistRepository
    {
        public async Task<IEnumerable<ReceptionistEntity>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            IQueryable<ReceptionistEntity> query = _dbContext.Receptionists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like((x.MiddleName + x.LastName + x.FirstName).ToLower(), $"%{nameLower}%"));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
