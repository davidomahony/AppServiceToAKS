using AirportFlightFinder.Models.Data;

namespace AirportFlightFinder.Models.Response
{
    public class GetAirportsResponse
    {
        public IEnumerable<Airport> Airports { get; set; }
    }
}
