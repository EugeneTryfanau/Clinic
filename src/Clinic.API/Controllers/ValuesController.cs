using Clinic.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController(ClinicDbContext context) : ControllerBase
{
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [HttpGet()]
    public async Task<IActionResult> GetById(CancellationToken ct)
    {
        var res = await context.Offices.ToListAsync();
        return Ok(res);
    }
}
