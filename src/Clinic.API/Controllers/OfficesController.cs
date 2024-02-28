using AutoMapper;
using Clinic.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficesController(IOfficeService officeService, IMapper mapper)
        {
            _officeService = officeService;
            _mapper = mapper;
        }

        
    }
}
