using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Areas.Admin.Dtos.Genre;
using MovieReviewApp.Areas.Admin.Interfaces;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Genres()
        {
            var list=await _genreRepository.GetAllAsync();
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateGenreDto createGenreDto)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.CreateAsync(createGenreDto);
            }
            return RedirectToAction("Genres","Genre",new {area="Admin"});
        }
        [HttpPost]
        public async Task<IActionResult> StatusChange(int id)
        {
            var model=await _genreRepository.StatusChangeAsync(id);
            if (model==null)
            {
                return RedirectToAction("Error", "Error", new { area = "" });
            }
            return RedirectToAction("Genres", "Genre", new { area = "Admin" });
        }
    }
}
