using Movie.API.Models.Movies;

namespace Movie.API.Clients
{
    public interface IOmdbClient
    {
        Task<MovieInfo> GetMovieInfo(string movieName);
    }
}
