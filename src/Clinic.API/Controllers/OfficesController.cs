using AutoMapper;
using Clinic.API.ViewModels.Office;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD;
using StandartCRUD.StandartAPI.Controllers;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OfficesController(IOfficeService officeService, IMapper mapper) :
        GenericController<Office, OfficeViewModel>(officeService, mapper)
    {
        [Authorize(Policy = "receptionist")]
        [HttpGet]
        public async Task<IEnumerable<OfficeViewModel>> GetAll(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var offices = await officeService.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<OfficeViewModel>>(offices);
        }
    }
}
