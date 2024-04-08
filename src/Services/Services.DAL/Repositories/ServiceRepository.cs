using Microsoft.EntityFrameworkCore;
using Services.DAL.Entities;
using Services.DAL.Interfaces;
using StandartCRUD;
using StandartCRUD.StandartDAL;

namespace Services.DAL.Repositories
{
    public class ServiceRepository(ServicesDbContext dbContext) :
        Repository<ServiceEntity, ServicesDbContext>(dbContext),
        IServiceRepository
    {
        public async Task<IEnumerable<ServiceEntity>> GetAllAsync(string? name, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            IQueryable<ServiceEntity> query = _dbContext.Services.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like(x.ServiceName.ToLower(), $"%{nameLower}%"));
            }

            if (isActive != null)
            {
                query = query.Where(x => x.IsActive == isActive);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}