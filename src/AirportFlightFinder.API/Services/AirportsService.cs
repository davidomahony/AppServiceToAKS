using AirportFlightFinder.API.Exceptions;
using AirportFlightFinder.API.Services.Interface;
using AirportFlightFinder.Models.Data;

namespace AirportFlightFinder.API.Services
{
    public class AirportsService : IAirportsService
    {
        private IList<Airport> _airports;

        public AirportsService()
        {
            _airports = new List<Airport>()
            {
                new Airport("cork", "ireland", "ork")
            };
        }

        public void AddAirport(Airport airport)
        {
            if (_airports.Contains(airport))
            {
                throw new BadRequestException("Duplicate airport entry");
            }

            ValidateAirportExists(airport.airportCode);

            _airports.Add(airport);
        }

        public IEnumerable<Airport> ListAirports()
        {
            return _airports;
        }

        public void RemoveAirport(Airport airport)
        {
            if (_airports.Contains(airport))
            {
                throw new BadRequestException("Airport entry does not exist");
            }

            _airports.Remove(airport);
        }

        private void ValidateAirportExists(string airportCode)
        {
            // Need to implement
        }
    }
}
