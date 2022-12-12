using System.Runtime.Serialization;

namespace Movie.API.Models
{
    public class MovieRated : MovieBase, IRatedMovie
    {
        public float MyRating { get; set; }
    }
}
