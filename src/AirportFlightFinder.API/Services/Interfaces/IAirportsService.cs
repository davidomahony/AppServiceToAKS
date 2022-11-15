using AirportFlightFinder.Models.Data;

namespace AirportFlightFinder.API.Services.Interface
{
    public interface IAirportsService
    {
        IEnumerable<Airport> ListAirports();

        void AddAirport(Airport airport);

        void RemoveAirport(Airport airport);
    }
}
