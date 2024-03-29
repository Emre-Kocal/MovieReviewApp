using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Interfaces;

namespace MovieReviewApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var actor=await _actorRepository.GetByIdAsync(id);
            if (actor==null)
            {
                //return error
            }
            return View(actor);
        }
    }
}
