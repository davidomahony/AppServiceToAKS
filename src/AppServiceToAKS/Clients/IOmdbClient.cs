using Movie.API.Models;

namespace Movie.API.Clients
{
    public interface IOmdbClient
    {
        Task<Movie.API.Models.Movie> GetMovieInfo(string movieName);
    }
}
