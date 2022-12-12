using System.Runtime.Serialization;

namespace Movie.API.Models.Movies
{
    public class MovieRated : MovieBase, IRatedMovie
    {
        public float MyRating { get; set; }
    }
}
