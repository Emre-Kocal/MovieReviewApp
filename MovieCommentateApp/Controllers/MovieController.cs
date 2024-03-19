using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
