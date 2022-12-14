using Movie.API.Models.Movies;

namespace Movie.API.Services
{
    public interface IWatchedMoviesService
    {
        IEnumerable<RatedMovieInfo> ListWatchedMovies();

        Task AddWatchedMovies(MovieRated watchedMovie);
    }
}
