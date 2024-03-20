using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Interfaces;

namespace MovieReviewApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public async Task<IActionResult> Movies()
        {
            var list=await _movieRepo.GetAllAsync();
            return View(list);
        }
    }
}
