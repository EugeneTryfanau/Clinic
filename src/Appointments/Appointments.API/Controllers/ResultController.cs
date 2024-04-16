using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Result;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD.StandartAPI.Controllers;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController(IRabbitMqProducerService mqService, IResultService resultService, IMapper mapper) :
        GenericController<Result, ResultViewModel>(resultService, mapper)
    {
        private readonly IResultService _resultService = resultService;
        private readonly IRabbitMqProducerService _mqService = mqService;

        [HttpGet]
        public async Task<IEnumerable<ResultViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var results = await _resultService.GetAllAsync(requestData.AppountmentId, cancellationToken);
            return _mapper.Map<IEnumerable<ResultViewModel>>(results);
        }

        [HttpPost]
        public async override Task<ResultViewModel> Create(ResultViewModel viewModel, CancellationToken cancellationToken)
        {
            var result = await base.Create(viewModel, cancellationToken);
            _mqService.SendMessage(result);
            return result;
        }
    }
}
