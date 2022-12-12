using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;

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

        public async void AddWatchedMovie(MovieBase movie)
        {
            var movieInfo = await this.GetMovieInfo(movie);

            _movies.Add(movieInfo);
        }

        public IEnumerable<MovieInfo> ListWatchedMovies() => _movies;

        public void RemoveWatchedMovie(MovieBase movie)
        {
            var movieToRemove = _movies.FirstOrDefault(x => 
                x.Title.Equals(movie.Title));
            if (movieToRemove is null)
            {
                throw new MovieNotFoundException();
            }

            _movies.Remove(movieToRemove);
        }

        private Task<MovieInfo> GetMovieInfo(MovieBase movie) => _movieClient.GetMovieInfo(movie.Title);
    }
}
