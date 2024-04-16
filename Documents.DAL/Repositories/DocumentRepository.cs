using Documents.DAL.Entities;
using Documents.DAL.Interfaces;
using StandartCRUD.StandartDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents.DAL.Repositories
{
    public class DocumentRepository(DocumentsDbContext dbContext) :
        Repository<DocumentEntity, DocumentsDbContext>(dbContext),
        IDocumentRepository
    {
        public Task<IEnumerable<DocumentEntity>> GetAllAsync(Guid resultId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
