using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Interfaces;

namespace MovieReviewApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IGenreRepository _genreRepo;

        public MovieController(IMovieRepository movieRepo, IGenreRepository genreRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
        }

        public async Task<IActionResult> Movies(QueryMovieDto query)
        {
            ViewBag.Genres = await _genreRepo.GetAllAsync();
            ViewBag.LastQuery=query;
            var list=await _movieRepo.GetAllAsync(query);
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
