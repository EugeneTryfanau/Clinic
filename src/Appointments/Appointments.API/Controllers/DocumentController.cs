using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Document;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController(IDocumentService documentService, IMapper mapper) : ControllerBase
    {
        private readonly IDocumentService _documentService = documentService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<DocumentViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var documents = await _documentService.GetAllAsync(requestData.ResultId, cancellationToken);

            return _mapper.Map<IEnumerable<DocumentViewModel>>(documents);
        }

        [HttpGet("{id}")]
        public async Task<DocumentViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<DocumentViewModel>(document);
        }

        [HttpPost]
        public async Task<DocumentViewModel> Create(CreateDocumentViewModel viewModel, CancellationToken cancellationToken)
        {
            var document = _mapper.Map<Document>(viewModel);
            var createResult = await _documentService.CreateAsync(document, cancellationToken);

            return _mapper.Map<DocumentViewModel>(createResult);
        }

        [HttpPut("{id}")]
        public async Task<DocumentViewModel> Update(Guid id, UpdateDocumentViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Document>(viewModel);
            modelToUpdate.Id = id;
            var result = await _documentService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<DocumentViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _documentService.DeleteAsync(id, cancellationToken);
        }
    }
}
