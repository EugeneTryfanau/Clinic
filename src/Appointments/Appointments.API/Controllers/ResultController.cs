using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Result;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController(IResultService resultService, IMapper mapper) : ControllerBase
    {
        private readonly IResultService _resultService = resultService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<ResultViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var results = await _resultService.GetAllAsync(requestData.AppountmentId, cancellationToken);

            return _mapper.Map<IEnumerable<ResultViewModel>>(results);
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _resultService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ResultViewModel>(result);
        }

        [HttpPost]
        public async Task<ResultViewModel> Create(CreateResultViewModel viewModel, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Result>(viewModel);
            var createResult = await _resultService.CreateAsync(result, cancellationToken);

            return _mapper.Map<ResultViewModel>(createResult);
        }

        [HttpPut("{id}")]
        public async Task<ResultViewModel> Update(Guid id, UpdateResultViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Result>(viewModel);
            modelToUpdate.Id = id;
            var result = await _resultService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<ResultViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _resultService.DeleteAsync(id, cancellationToken);
        }
    }
}
