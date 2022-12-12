namespace Movie.API.Models.Responses
{
    public class GetWatchedMoviesReponse
    {
        public IEnumerable<RatedMovieInfo> WatchedMovies { get; set; }
    }
}
