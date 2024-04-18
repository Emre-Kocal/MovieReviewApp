using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Areas.Admin.Dtos.ActorMovie;
using MovieReviewApp.Areas.Admin.Interfaces;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ActorMovieController : Controller
    {
        private readonly IActorMovieRepository _actorMovieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository;

        public ActorMovieController(IActorMovieRepository actorMovieRepository, IActorRepository actorRepository, IMovieRepository movieRepository)
        {
            _actorMovieRepository = actorMovieRepository;
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int movieId)
        {
            ViewBag.Movie=await _movieRepository.GetByIdAsync(movieId);
            ViewBag.Actors=await _actorRepository.GetAllAsyncExceptFor(movieId);
            var list = await _actorMovieRepository.GetAllByMovieAsync(movieId);
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ActorMovieDto actorMovie)
        {
            await _actorMovieRepository.CreateAsync(actorMovie);
            return RedirectToAction("Index", "ActorMovie", new {area="Admin",movieId=actorMovie.MovieId});
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ActorMovieDto actorMovie)
        {
            await _actorMovieRepository.DeleteAsync(actorMovie);
            return RedirectToAction("Index", "ActorMovie", new { area = "Admin", movieId = actorMovie.MovieId });
        }
    }
}
