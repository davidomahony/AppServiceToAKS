using Movie.API.Models.Movies;

namespace Movie.API.Services
{
    public interface IWatchListServices
    {
        IEnumerable<MovieInfo> ListWatchedMovies();

        void AddWatchedMovie(MovieBase movie);

        void RemoveWatchedMovie(MovieBase movie);
    }
}
