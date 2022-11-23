using AirportFlightFinder.Models.Clients.FlightsClient;

namespace AirportFlightFinder.API.Clients
{
    public interface IFlightInfoClient
    {
        Task<RealTimeFlightResponse> GetRealTimeFlightInfo(string flightCode);
    }
}
