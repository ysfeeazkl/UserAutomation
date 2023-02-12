using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserAutomation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyControllers : ControllerBase
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok("ok");
        }
    }
}
