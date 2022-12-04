namespace Movie.API.Models.Responses
{
    public class GetWatchedMoviesReponse
    {
        public IEnumerable<MovieRated> WatchedMovies { get; set; }
    }
}
