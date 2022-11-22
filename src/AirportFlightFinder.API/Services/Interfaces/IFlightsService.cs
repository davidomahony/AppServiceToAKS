using AirportFlightFinder.Models.Data;

namespace AirportFlightFinder.API.Services.Interfaces
{
    public interface IFlightsService
    {
        FlightInfo GetFlightDetails(string flightCode);
    }
}
