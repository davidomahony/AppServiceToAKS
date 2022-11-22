using AirportFlightFinder.API.Services.Interface;
using AirportFlightFinder.Models.Requests;
using AirportFlightFinder.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace AirportFlightFinder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportsService _airportsService;

        public AirportsController(IAirportsService airportsService)
        {
            _airportsService = airportsService  ?? throw new ArgumentNullException(nameof(airportsService));
        }

        [HttpGet()]
        public IActionResult ListAirports()
        {
            GetAirportsResponse response = new GetAirportsResponse()
            {
                Airports = _airportsService.ListAirports()
            };

            return Ok(response);
        }


        [HttpPost("AddAirport")]
        public IActionResult AddAirport(AddAirportRequest request)
        {
            _airportsService.AddAirport(request.AirportToAdd);

            return Ok();
        }

        [HttpPost("RemoveAirport")]
        public IActionResult RemoveAirport(RemoveAirportRequest request)
        {
            try
            {
                _airportsService.RemoveAirport(request.AirportToRemove);
            }
            catch (Exception ex)
            {
                //should catch the not found
            }

            return Ok();
        }
    }
}
