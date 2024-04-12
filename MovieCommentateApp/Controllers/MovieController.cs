using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;
using System.Security.Claims;

namespace MovieReviewApp.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public MovieController(IMovieRepository movieRepo, IGenreRepository genreRepo, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Movies(QueryMovieDto query)
        {
            ViewBag.Genres = await _genreRepo.GetAllAsync();
            var list=await _movieRepo.GetAllAsync(query);
            ViewBag.LastQuery = query;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                //return error 
            }
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.userRole = roles[0];
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _movieRepo.GetByIdWithAllAsync(id);
            if (movie==null)
            {
                //return Error
            }
            ViewData["userId"] = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                //return error 
            }
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.userRole = roles[0];
            return View(movie);
        }
    }
}
