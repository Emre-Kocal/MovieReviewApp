using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly SignInManager<AppUser> _signInManager;

        public MovieController(IMovieRepository movieRepo, IGenreRepository genreRepo, SignInManager<AppUser> signInManager)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Movies(QueryMovieDto query)
        {
            ViewBag.Genres = await _genreRepo.GetAllAsync();
            var list=await _movieRepo.GetAllAsync(query);
            ViewBag.LastQuery = query;
            return View(list);
        }
        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _movieRepo.GetByIdWithAllAsync(id);
            if (movie==null)
            {
                //return Error
            }
            return View(movie);
        }
    }
}
