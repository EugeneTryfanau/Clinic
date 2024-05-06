using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.API.ViewModels;
using Services.API.ViewModels.Service;
using Services.BLL.Interfaces;
using Services.BLL.Models;

namespace Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServiceService serviceService, IMapper mapper) : ControllerBase
    {
        private readonly IServiceService _serviceService = serviceService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<ServiceViewModel>> GetAll([FromQuery]ServiceSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var services = await _serviceService.GetAllAsync(requestData.Name, requestData.IsActive, cancellationToken);

            return _mapper.Map<IEnumerable<ServiceViewModel>>(services);
        }

        [HttpGet("{id}")]
        public async Task<ServiceViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var service = await _serviceService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ServiceViewModel>(service);
        }

        [HttpPost]
        public async Task<ServiceViewModel> Create(CreateServiceViewModel viewModel, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(viewModel);
            var result = await _serviceService.CreateAsync(service, cancellationToken);

            return _mapper.Map<ServiceViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<ServiceViewModel> Update(Guid id, UpdateServiceViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Service>(viewModel);
            modelToUpdate.Id = id;
            var result = await _serviceService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<ServiceViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _serviceService.DeleteAsync(id, cancellationToken);
        }
    }
}
