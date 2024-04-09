using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using AutoMapper;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Services
{
    public class DocumentService(IDocumentRepository documentRepository, IMapper mapper) :
        GenericService<DocumentEntity, Document>(documentRepository, mapper),
        IDocumentService
    {
        private readonly IDocumentRepository _documentRepository = documentRepository;

        public async Task<IEnumerable<Document>> GetAllAsync(Guid? resultId, CancellationToken cancellationToken)
        {
            var documents = await _documentRepository.GetAllAsync(resultId, cancellationToken);

            return _mapper.Map<IEnumerable<Document>>(documents);
        }
    }
}
