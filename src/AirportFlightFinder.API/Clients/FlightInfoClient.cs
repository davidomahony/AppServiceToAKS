using AirportFlightFinder.Models.Clients.FlightsClient;

namespace AirportFlightFinder.API.Clients
{
    public class FlightInfoClient : IFlightInfoClient
    {
        private string AccessKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiI0I" +
            "iwianRpIjoiNDcxNTIwZmRkZWUwNTkyMGM3ZjE2ZDg4OTU1YzFhMjY3ZDk3ODAwNjZmNmI4ZmR" +
            "kMzA0MDMyYzA3YjRhYTVlZjhmYWQ3ODk1N2JhNzEwYzEiLCJpYXQiOjE2Njg1NDUyNjUsIm5iZi" +
            "I6MTY2ODU0NTI2NSwiZXhwIjoxNzAwMDgxMjY1LCJzdWIiOiIxODM2NCIsInNjb3BlcyI6W119.P" +
            "vs8uG0uZ0HMVe1QyHPSF1_U0YPkZPYR0SsR1YxAWbr_oCCtQ5_W4gUK_-QamNXP9p84lAR1TncMI" +
            "ka8jvspEg";

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
