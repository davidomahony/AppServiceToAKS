namespace AirportFlightFinder.Models.Clients.FlightsClient
{
    public class RealTimeFlightResponse
    {
        public bool Success { get; set; }

        public Data[] Data { get; set; }
    }

    public class Data
    {
        public Aircraft Aircraft { get; set; }

        public Airline  Airline { get; set; }

        public AirportCode Arrival { get; set; }

        public AirportCode Departure { get; set; }
    }

    public class Aircraft
    {
        public string IataCode { get; set; }

        public string Icao24 { get; set; }

        public string IcaoCode { get; set; }

        public string RegNumber { get; set; }
    }

    public class Airline
    {
        public string IataCode { get; set; }

        public string Icao24 { get; set; }
    }

    public class AirportCode
    {
        public string IataCode { get; set; }

        public string IcaoCode { get; set; }
    }
}
