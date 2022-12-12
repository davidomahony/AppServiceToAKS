using Movie.API.Models;

namespace Movie.API.Services
{
    public interface IWatchedMoviesService
    {
        IEnumerable<RatedMovieInfo> ListWatchedMovies();

        void AddWatchedMovies(MovieRated watchedMovie);
    }
}
