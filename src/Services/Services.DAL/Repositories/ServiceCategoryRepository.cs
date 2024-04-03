using Microsoft.EntityFrameworkCore;
using Services.DAL.Entities;
using Services.DAL.Interfaces;
using StandartCRUD.StandartDAL;

namespace Services.DAL.Repositories
{
    public class ServiceCategoryRepository(ServicesDbContext dbContext) :
        Repository<ServiceCategoryEntity, ServicesDbContext>(dbContext),
        IServiceCategoryRepository
    {
        public async Task<IEnumerable<ServiceEntity>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            IQueryable<ServiceEntity> query = _dbContext.Services.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like(x.ServiceName.ToLower(), $"%{nameLower}%"));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
