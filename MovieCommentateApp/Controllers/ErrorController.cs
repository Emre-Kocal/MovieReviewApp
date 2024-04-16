using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
