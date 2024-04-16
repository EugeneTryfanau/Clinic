using Documents.DAL.Entities;
using Documents.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StandartCRUD.StandartDAL;

namespace Documents.DAL.Repositories
{
    public class DocumentRepository(DocumentsDbContext dbContext) :
        Repository<DocumentEntity, DocumentsDbContext>(dbContext),
        IDocumentRepository
    {
        public async Task<IEnumerable<DocumentEntity>> GetAllAsync(Guid resultId, CancellationToken cancellationToken)
        {
            IQueryable<DocumentEntity> query = _dbContext.Documents.AsQueryable();

            if (resultId != Guid.Empty)
            {
                query = query.Where(x => x.ResultId == resultId);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
