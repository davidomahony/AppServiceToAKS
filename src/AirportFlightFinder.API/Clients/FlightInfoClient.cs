using AirportFlightFinder.Models.Clients.FlightsClient;

namespace AirportFlightFinder.API.Clients
{
    public class FlightInfoClient : IFlightInfoClient
    {
        private string AccessKey = "Not today buddy";

        private readonly HttpClient _client;

        public FlightInfoClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<RealTimeFlightResponse> GetRealTimeFlightInfo(string flightCode)
        {
            var request = $"advanced-real-time-flights?access_key={AccessKey}&flightNum={flightCode}";

            var result = await _client.GetAsync(request);

            var resultContent = result.Content.ReadFromJsonAsync<object>();


            return null;

        }
    }
}
