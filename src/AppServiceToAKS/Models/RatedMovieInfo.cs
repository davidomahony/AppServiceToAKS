namespace Movie.API.Models
{
    public class RatedMovieInfo : MovieInfo, IRatedMovie
    {
        public RatedMovieInfo(MovieInfo info, IRatedMovie ratedMovie)
        {
            this.Title = info.Title;
            this.ImdbRating = info.ImdbRating;
            this.Genre = info.Genre;
            this.MyRating = ratedMovie.MyRating;
        }

        public float MyRating { get; set; }
    }
}
