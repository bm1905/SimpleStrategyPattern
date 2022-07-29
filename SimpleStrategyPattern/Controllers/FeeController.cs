using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StrategyPattern.BLL;
using StrategyPattern.Models;

namespace StrategyPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeeController :ControllerBase
    {
        private readonly ILogger<FeeController> _logger;
        private readonly IProcessFeeService _processFeeService;

        public FeeController(ILogger<FeeController> logger, IProcessFeeService processFeeService)
        {
            _logger = logger;
            _processFeeService = processFeeService;
        }

        [HttpPost]
        public async Task<ActionResult<FeeModel>> Post([FromBody] DataInput dataInput)
        {
            _logger.LogInformation("Invoked POST method");
            var response = await _processFeeService.CalculateCharges(dataInput);
            return Ok(response);
        }
    }
}
