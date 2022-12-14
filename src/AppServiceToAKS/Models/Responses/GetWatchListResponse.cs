using Movie.API.Models.Movies;

namespace Movie.API.Models.Responses
{
    public class GetWatchListResponse
    {
        public IEnumerable<MovieInfo>? Movies { get; set; }
    }
}
