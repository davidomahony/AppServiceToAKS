using Microsoft.AspNetCore.Mvc;
using Movie.API.Models.Responses;
using Movie.API.Services;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchedController : ControllerBase
    {
        private readonly IWatchedMoviesService _watchedMoviesService;

        public WatchedController(IWatchedMoviesService watchedMoviesService)
        {
            _watchedMoviesService = watchedMoviesService;
        }

        [HttpGet(Name = "List")]
        public IActionResult ListWatchedMovies()
        {

            try
            {
                return Ok(
                    new ListWatchedMoviesReponse()
                    {
                        WatchedMovies = _watchedMoviesService.ListWatchedMovies()
                    });
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost(Name = "Add")]
        public IActionResult AddWatchedMovies()
        {
            return new OkResult();
        }
    }
}
