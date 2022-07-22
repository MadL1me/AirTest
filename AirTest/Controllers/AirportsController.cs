using AirRest.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public AirportsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("/distance/calc")]
        public async Task<ActionResult<double>> GetDistanceBetweenTwoAirports(
            [FromQuery] string firstAirportIata, 
            [FromQuery] string secondAirportIata)
        {
            return await _applicationService.GetDistanceBetweenTwoAirports(firstAirportIata, secondAirportIata);
        }
    }
}
