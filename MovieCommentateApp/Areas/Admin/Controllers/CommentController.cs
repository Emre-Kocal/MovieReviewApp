using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Areas.Admin.Interfaces;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CommentDelete(int id)
        {
            var userId = await _commentRepository.GetUsersIdAsync(id);
            await _commentRepository.Delete(id);
            return RedirectToAction("UserDetails", "User", new {area="Admin",id=userId});
        }
    }
}
