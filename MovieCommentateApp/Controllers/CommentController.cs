using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Interfaces;

namespace MovieReviewApp.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CommentAdd(CommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ModelStateErrors"] = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
            }
            else
            {
                await _commentRepository.CreateAsync(commentDto);
            }
            return RedirectToAction("MovieDetails", "Movie", new { id = commentDto.MovieId });
        }
    }
}
