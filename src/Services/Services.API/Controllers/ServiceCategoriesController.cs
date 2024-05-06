using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.API.ViewModels;
using Services.API.ViewModels.ServiceCategory;
using Services.BLL.Interfaces;
using Services.BLL.Models;

namespace Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController(IServiceCategoryService serviceCategoryService, IMapper mapper) : ControllerBase
    {
        private readonly IServiceCategoryService _serviceCategoryService = serviceCategoryService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<ServiceCategoryViewModel>> GetAll([FromQuery]ServiceSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var serviceCategories = await _serviceCategoryService.GetAllAsync(requestData.Name, cancellationToken);

            return _mapper.Map<IEnumerable<ServiceCategoryViewModel>>(serviceCategories);
        }

        [HttpGet("{id}")]
        public async Task<ServiceCategoryViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var serviceCategory = await _serviceCategoryService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ServiceCategoryViewModel>(serviceCategory);
        }

        [HttpPost]
        public async Task<ServiceCategoryViewModel> Create(CreateServiceCategoryViewModel viewModel, CancellationToken cancellationToken)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(viewModel);
            var result = await _serviceCategoryService.CreateAsync(serviceCategory, cancellationToken);

            return _mapper.Map<ServiceCategoryViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<ServiceCategoryViewModel> Update(Guid id, UpdateServiceCategoryViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<ServiceCategory>(viewModel);
            modelToUpdate.Id = id;
            var result = await _serviceCategoryService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<ServiceCategoryViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _serviceCategoryService.DeleteAsync(id, cancellationToken);
        }
    }
}
