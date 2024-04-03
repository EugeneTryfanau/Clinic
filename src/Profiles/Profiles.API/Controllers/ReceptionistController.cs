using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels;
using Profiles.API.ViewModels.Receptionist;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Models;

namespace Profiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController(IReceptionistService receptionistService, IMapper mapper) : ControllerBase
    {
        private readonly IReceptionistService _receptionistService = receptionistService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<ReceptionistViewModel>> GetAll(ProfileSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var receptionists = await _receptionistService.GetAllAsync(requestData.Name, cancellationToken);

            return _mapper.Map<IEnumerable<ReceptionistViewModel>>(receptionists);
        }

        [HttpGet("{id}")]
        public async Task<ReceptionistViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var receptionist = await _receptionistService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ReceptionistViewModel>(receptionist);
        }

        [HttpPost]
        public async Task<ReceptionistViewModel> Create(CreateReceptionistViewModel viewModel, CancellationToken cancellationToken)
        {
            var receptionist = _mapper.Map<Receptionist>(viewModel);
            var result = await _receptionistService.CreateAsync(receptionist, cancellationToken);

            return _mapper.Map<ReceptionistViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<ReceptionistViewModel> Update(Guid id, UpdateReceptionistViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Receptionist>(viewModel);
            modelToUpdate.Id = id;
            var result = await _receptionistService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<ReceptionistViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _receptionistService.DeleteAsync(id, cancellationToken);
        }
    }
}
