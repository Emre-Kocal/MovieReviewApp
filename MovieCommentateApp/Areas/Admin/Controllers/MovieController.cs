using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Areas.Admin.Dtos.Movie;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Interfaces;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly MovieReviewApp.Areas.Admin.Interfaces.IMovieRepository _movieRepository;
        private readonly MovieReviewApp.Interfaces.IGenreRepository _genreRepository;

        public MovieController(Interfaces.IMovieRepository movieRepository, MovieReviewApp.Interfaces.IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Movies()
        {
            var list=await _movieRepository.GetAllAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Genres=await _genreRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieDto createMovieDto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Movies", "Movie", new { area = "Admin" });

            await _movieRepository.CreateAsync(createMovieDto);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model=await _movieRepository.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMovieDto updateMovieDto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Movies", "Movie", new { area = "Admin" });

            var model=await _movieRepository.UpdateAsync(updateMovieDto);
            if (model==null)
            {
                //return error
            }
            return RedirectToAction("Movies", "Movie", new {area="Admin"});
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model=await _movieRepository.DeleteAsync(id);
            if (model == null)
            {
                //return error
            }
            return RedirectToAction("Movies", "Movie", new { area = "Admin" });
        }
    }
}
