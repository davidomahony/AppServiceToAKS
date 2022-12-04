namespace Movie.API.Services
{
    public interface IWatchListServices
    {
        IEnumerable<Movie.API.Models.Movie> ListWatchedMovies();

        void AddWatchedMovie(Movie.API.Models.Movie movie);

        void RemoveWatchedMovie(Movie.API.Models.Movie movie);
    }
}
