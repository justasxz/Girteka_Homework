using Girteka_Homework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Girteka_Homework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgreggatedDataController : ControllerBase
    {

        private readonly ILogger<AgreggatedDataController> _logger;
        private readonly IAggregationService _aggregationService;

        public AgreggatedDataController(ILogger<AgreggatedDataController> logger, IAggregationService aggregationService)
        {
            _aggregationService = aggregationService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into AgreggatedDataController");
        }

        [HttpGet]
        public async Task<IActionResult> GetAggregatedData()
        {
            try
            {
                _logger.LogWarning("Hi, fellow programmer! I know how to log.");

                var records = _aggregationService.GetAggregatedData();

                if (records.Any())
                    return Ok(records);

                return BadRequest("The data could not be aggregated and retrieved");
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an unexpected error during the request");
                return BadRequest("There was an unexpected error during the request");
            }
        }

    }
}