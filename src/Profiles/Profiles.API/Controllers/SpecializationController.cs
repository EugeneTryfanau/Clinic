using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels;
using Profiles.API.ViewModels.Specialization;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;

namespace Profiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController(ISpecializationService specializationService, IMapper mapper) : ControllerBase
    {
        private readonly ISpecializationService _specializationService = specializationService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<SpecializationViewModel>> GetAll(ProfileSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var specs = await _specializationService.GetAllAsync(requestData.Name, cancellationToken);

            return _mapper.Map<IEnumerable<SpecializationViewModel>>(specs);
        }

        [HttpGet("{id}")]
        public async Task<SpecializationViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var spec = await _specializationService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<SpecializationViewModel>(spec);
        }

        [HttpPost]
        public async Task<SpecializationViewModel> Create(CreateSpecializationViewModel viewModel, CancellationToken cancellationToken)
        {
            var spec = _mapper.Map<Specialization>(viewModel);
            var result = await _specializationService.CreateAsync(spec, cancellationToken);

            return _mapper.Map<SpecializationViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<SpecializationViewModel> Update(Guid id, UpdateSpecializationViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Specialization>(viewModel);
            modelToUpdate.Id = id;
            var result = await _specializationService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<SpecializationViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _specializationService.DeleteAsync(id, cancellationToken);
        }
    }
}
