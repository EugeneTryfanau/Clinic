using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Document;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD.StandartAPI.Controllers;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController(IDocumentService documentService, IMapper mapper) :
        GenericController<Document, DocumentViewModel>(documentService, mapper)
    {
        private readonly IDocumentService _documentService = documentService;

        [HttpGet]
        public async Task<IEnumerable<DocumentViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var documents = await _documentService.GetAllAsync(requestData.ResultId, cancellationToken);

            return _mapper.Map<IEnumerable<DocumentViewModel>>(documents);
        }
    }
}
