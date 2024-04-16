using AutoMapper;
using Documents.BLL.Interfaces;
using Documents.BLL.Models;
using Documents.DAL.Entities;
using Documents.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Documents.BLL.Services
{
    public class DocumentService(IDocumentRepository documentRepository, IMapper mapper) :
        GenericService<DocumentEntity, Document>(documentRepository, mapper),
        IDocumentService
    {
        public async Task<IEnumerable<Document>> GetAllAsync(Guid resultId, CancellationToken cancellationToken)
        {
            var documents = await documentRepository.GetAllAsync(resultId, cancellationToken);

            return _mapper.Map<IEnumerable<Document>>(documents);
        }
    }
}
