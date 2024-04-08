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
    public class ResultController(IResultService resultService, IMapper mapper) :
        BaseController<Result, ResultViewModel, CreateResultViewModel, UpdateResultViewModel>(resultService, mapper)
    {
        private readonly IResultService _resultService = resultService;

        [HttpGet]
        public async Task<IEnumerable<ResultViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var results = await _resultService.GetAllAsync(requestData.AppountmentId, cancellationToken);

            return _mapper.Map<IEnumerable<ResultViewModel>>(results);
        }
    }
}
