using Microsoft.AspNetCore.Mvc;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Models.Responses;
using Movie.API.Services;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListServices _watchListServicecs;

        public WatchListController(IWatchListServices watchListServicecs)
        {
            _watchListServicecs = watchListServicecs ?? throw new ArgumentException(nameof(watchListServicecs));
        }

        [HttpGet]
        public IActionResult GetWatchList()
        {
            try
            {
                return Ok(new GetWatchListResponse { Movies = _watchListServicecs.ListWatchedMovies()});
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        public IActionResult AddMovie(MovieBase movieToAdd)
        {
            try
            {
                _watchListServicecs.AddWatchedMovie(movieToAdd);
                return Accepted();
            }
            catch (MovieNotFoundException)
            {
                return NotFound("Movie not found");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveMovie(MovieBase movieToRemove)
        {
            try
            {
                _watchListServicecs.RemoveWatchedMovie(movieToRemove);
                return Accepted();
            }
            catch (MovieNotFoundException)
            {
                return NotFound("Movie not in watch list");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
