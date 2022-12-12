using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models;

namespace Movie.API.Services
{
    public class WatchListServices : IWatchListServices
    {
        private readonly IList<MovieInfo> _movies;
        private readonly IOmdbClient _movieClient;

        public WatchListServices(IOmdbClient movieClient)
        {
            _movies = new List<MovieInfo>();
            _movieClient = movieClient;
        }

        public void AddWatchedMovie(Models.MovieBase movie)
        {
            var movieInfo = this.GetMovieInfo(movie);

            _movies.Add(movieInfo);
        }

        public IEnumerable<MovieInfo> ListWatchedMovies()
        {
            return _movies;
        }

        public void RemoveWatchedMovie(Models.MovieBase movie)
        {
            var movieToRemove = _movies.First(x => 
                x.Title.Equals(movie.Title));
            if (movieToRemove is null)
            {
                throw new MovieNotFoundException();
            }

            _movies.Remove(movieToRemove);
        }

        private MovieInfo GetMovieInfo(MovieBase movie)
        {
            return _movieClient.GetMovieInfo(movie.Title).Result;
        }
    }
}
