using Movie.API.Models.Movies;

namespace Movie.API.Services
{
    public interface IWatchListServices
    {
        IEnumerable<MovieInfo> ListWatchedMovies();

        Task AddWatchedMovie(MovieBase movie);

        void RemoveWatchedMovie(MovieBase movie);
    }
}
