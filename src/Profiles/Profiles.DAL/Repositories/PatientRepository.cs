using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Repositories
{
    public class PatientRepository(ProfilesDbContext dbContext) : 
        Repository<PatientEntity, ProfilesDbContext>(dbContext), 
        IPatientRepository
    {
        public async Task<IEnumerable<PatientEntity>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            IQueryable<PatientEntity> query = _dbContext.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like((x.MiddleName + x.LastName + x.FirstName).ToLower(), $"%{name}%"));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
