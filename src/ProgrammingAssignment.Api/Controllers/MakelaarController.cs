using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProgrammingAssignment.Application.Makelaars;
using Refit;

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
            catch (ApiException ex)
            {
                return ex.StatusCode switch
                {
                    HttpStatusCode.NotFound => NotFound(new { message = "Geen woningen gevonden voor deze locatie." }),
                    HttpStatusCode.TooManyRequests => StatusCode(429,
                        new { message = "Te veel aanvragen. Probeer het later opnieuw." }),
                    _ => StatusCode(500, new { message = "Er ging iets mis bij het ophalen van de woningen." })
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Er is een interne fout opgetreden: {ex.Message}." });
            }
        }
    }
}
