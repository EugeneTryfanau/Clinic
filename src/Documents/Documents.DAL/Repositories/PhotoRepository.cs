using Documents.DAL.Entities;
using Documents.DAL.Interfaces;
using StandartCRUD.StandartDAL;

namespace Documents.DAL.Repositories
{
    public class PhotoRepository(DocumentsDbContext dbContext) :
    Repository<PhotoEntity, DocumentsDbContext>(dbContext),
    IPhotoRepository
    {
    }
}
