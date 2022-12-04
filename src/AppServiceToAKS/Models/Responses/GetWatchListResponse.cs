namespace Movie.API.Models.Responses
{
    public class GetWatchListResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
