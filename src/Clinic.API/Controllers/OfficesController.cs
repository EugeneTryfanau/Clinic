using AutoMapper;
using Clinic.API.ViewModels.Office;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OfficesController(IRabbitMqProducerService mqService, IOfficeService officeService, IMapper mapper) : ControllerBase
    {
        private readonly IOfficeService _officeService = officeService;
        private readonly IRabbitMqProducerService _mqService = mqService;
        private readonly IMapper _mapper = mapper;

        [Authorize(Policy = "receptionist")]
        [HttpGet]
        public async Task<IEnumerable<OfficeViewModel>> GetAll(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var offices = await _officeService.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<OfficeViewModel>>(offices);
        }

        [HttpGet("{id}")]
        public async Task<OfficeViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var actor = await _officeService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<OfficeViewModel>(actor);
        }

        [HttpPost]
        public async Task<OfficeViewModel> Create(CreateOfficeViewModel viewModel, CancellationToken cancellationToken)
        {
            var office = _mapper.Map<Office>(viewModel);
            var result = await _officeService.CreateAsync(office, cancellationToken);

            return _mapper.Map<OfficeViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<OfficeViewModel> Update(Guid id, UpdateOfficeViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Office>(viewModel);
            modelToUpdate.Id = id;
            var result = await _officeService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<OfficeViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var modelToDelete = await _officeService.GetByIdAsync(id, cancellationToken);
            await _officeService.DeleteAsync(id, cancellationToken);
            _mqService.SendMessage(modelToDelete);
        }
    }
}
