using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StandartCRUD.StandartDAL
{
    public class Repository<T, TContext>(TContext dbContext) : 
        IRepository<T> where T : class
        where TContext : DbContext
    {
        protected readonly TContext _dbContext = dbContext;

        public async virtual Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async virtual Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        }

        public async virtual Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async virtual Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async virtual Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async virtual Task<IEnumerable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }
    }
}