using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieReviewApp.Areas.Admin.Dtos.Movie;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;
using NuGet.Versioning;

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
            var list = await _movieRepository.GetAllAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Genres = await _genreRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieDto createMovieDto, IFormFile? formFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = await _genreRepository.GetAllAsync();
                return View();
            }

            string newMovieFile = _movieRepository.ImageAdd(formFile);
            createMovieDto.PosterImage = newMovieFile;
            await _movieRepository.CreateAsync(createMovieDto);
            return RedirectToAction("Movies", "Movie", new { area = "Admin" });

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _movieRepository.GetByIdAsync(id);
            ViewBag.Genres = await _genreRepository.GetAllAsync();
            if (model==null)
                return RedirectToAction("Error", "Error", new { area = "" });
            return View(model.MovieToUpdateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMovieDto updateMovieDto,IFormFile? formFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = await _genreRepository.GetAllAsync();
                return View(updateMovieDto);
            }

            var oldmodel = await _movieRepository.GetByIdAsync(updateMovieDto.Id);

            if (oldmodel == null)
                return RedirectToAction("Error", "Error", new { area = "" });

            string newMovieFile="";
            if (formFile != null && oldmodel.PosterImage!=null)
            {
                newMovieFile = _movieRepository.ImageUpdate(formFile, oldmodel.PosterImage);
            }
            else if (formFile != null)
            {
                newMovieFile = _movieRepository.ImageAdd(formFile);
            }
            else if (oldmodel.PosterImage!=null)
            {
                newMovieFile=oldmodel.PosterImage;
            }

            updateMovieDto.PosterImage= newMovieFile;
            await _movieRepository.UpdateAsync(updateMovieDto);

            return RedirectToAction("Movies", "Movie", new { area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _movieRepository.DeleteAsync(id);
            if (model == null)
                return RedirectToAction("Error", "Error", new { area = "" });

            return RedirectToAction("Movies", "Movie", new { area = "Admin" });
        }
    }
}
