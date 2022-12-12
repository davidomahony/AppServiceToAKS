using Movie.API.Models;

namespace Movie.API.Services
{
    public interface IWatchListServices
    {
        IEnumerable<MovieInfo> ListWatchedMovies();

        void AddWatchedMovie(Movie.API.Models.MovieBase movie);

        void RemoveWatchedMovie(Movie.API.Models.MovieBase movie);
    }
}
