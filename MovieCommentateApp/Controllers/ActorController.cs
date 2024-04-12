using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;
        private readonly UserManager<AppUser> _userManager;

        public ActorController(IActorRepository actorRepository, UserManager<AppUser> userManager)
        {
            _actorRepository = actorRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            var actor=await _actorRepository.GetByIdAsync(id);
            if (actor==null)
            {
                //return error
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                //return error 
            }
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.userRole = roles[0];
            return View(actor);
        }
    }
}
