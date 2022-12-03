using Movie.API.Models;

namespace Movie.API.Services
{
    public interface IWatchedMoviesService
    {
        IEnumerable<MovieRated> ListWatchedMovies();

        void AddWatchedMovies(MovieRated watchedMovie);
    }
}
