using Microsoft.AspNetCore.Mvc;

namespace ProgrammingAssignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakelaarController(ILogger<MakelaarController> logger) : ControllerBase
    {
        private readonly ILogger<MakelaarController> _logger = logger;

        [HttpPost(Name = "ProcessMakelaarsTopList")]
        public IEnumerable<Makelaar> ProcessMakelaarsTopList()
        {
            _logger.LogInformation("MakelaarController.ProcessMakelaarsTopList");
            throw new NotImplementedException();
        }
    }
}
