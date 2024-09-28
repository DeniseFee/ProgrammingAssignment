using Microsoft.AspNetCore.Mvc;
using ProgrammingAssignment.Application.Makelaars;

namespace ProgrammingAssignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakelaarController(IMakelaarService makelaarService) : ControllerBase
    {

        [HttpPost("{plaats}")]
        public async Task<IActionResult> ProcessMakelaarsTopListAsync(string plaats)
        {
            try
            {
                var topList = await makelaarService.ProcessMakelaarsTopListAsync(plaats);
                return Ok(topList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
