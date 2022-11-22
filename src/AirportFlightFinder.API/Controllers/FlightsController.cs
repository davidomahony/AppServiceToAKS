using AirportFlightFinder.API.Services.Interfaces;
using AirportFlightFinder.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirportFlightFinder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService ?? throw new ArgumentNullException(nameof(flightsService));
        }

        [HttpGet("flightdetails")]
        public IActionResult FlightDetails([FromRoute] string flightCode)
        {
            FlightInfo result = _flightsService.GetFlightDetails(flightCode);

            if (result is null)
                return NotFound($"Flight {flightCode} is not found");

            return Ok(result);
        }
    }
}
