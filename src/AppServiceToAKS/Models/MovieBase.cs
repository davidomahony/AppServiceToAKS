using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Movie.API.Models
{
    public class MovieBase
    {
        [Required]
        public string Title { get; set; }
    }
}
