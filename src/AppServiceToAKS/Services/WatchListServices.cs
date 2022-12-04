using Movie.API.Clients;
using Movie.API.Exceptions;

namespace Movie.API.Services
{
    public class WatchListServices : IWatchListServices
    {
        private readonly IList<Movie.API.Models.Movie> _movies;
        private readonly IOmdbClient _movieClient;

        public WatchListServices(IOmdbClient movieClient)
        {
            _movies = new List<Movie.API.Models.Movie>();
            _movieClient = movieClient;
        }

        public void AddWatchedMovie(Models.Movie movie)
        {
            this.ValidateMovie(movie);

            _movies.Add(movie);
        }

        public IEnumerable<Models.Movie> ListWatchedMovies()
        {
            return _movies;
        }

        public void RemoveWatchedMovie(Models.Movie movie)
        {
            var movieToRemove = _movies.First(x => 
                x.Title.Equals(movie.Title));
            if (movieToRemove is null)
            {
                throw new MovieNotFoundException();
            }

            _movies.Remove(movieToRemove);
        }

        private void ValidateMovie(Movie.API.Models.Movie movie)
        {
            var movieInfo = _movieClient.GetMovieInfo(movie.Title).Result;
            if (movieInfo is null)
            {
                throw new MovieNotFoundException();
            }
        }
    }
}
