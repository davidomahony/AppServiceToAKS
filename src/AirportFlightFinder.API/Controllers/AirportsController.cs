using AirportFlightFinder.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AirportFlightFinder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportsService airportsService;

        public AirportsController(IAirportsService airportsService)
        {
            this.airportsService = airportsService  ?? throw new ArgumentNullException(nameof(airportsService));
        }


        [HttpPost("AddAirport")]
        public IActionResult AddAirport(AddAirportRequest request)
        {

            return Ok();
        }

        [HttpPost("RemoveAirport")]
        public IActionResult RemoveAirport(RemoveAirportRequest request)
        {

            return Ok();
        }
    }
}
