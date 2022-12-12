using Movie.API.Models;

namespace Movie.API.Clients
{
    public interface IOmdbClient
    {
        Task<MovieInfo> GetMovieInfo(string movieName);
    }
}
