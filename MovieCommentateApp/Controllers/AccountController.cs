using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dtos.Account;
using MovieReviewApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }
            var existingEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError(string.Empty, "The email is already in use.");
                return View(registerDto);
            }

            var existingUser = await _userManager.FindByNameAsync(registerDto.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "The username is already in use.");
                return View(registerDto);
            }

            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!createdUser.Succeeded)
            {
                foreach (var error in createdUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerDto);
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerDto);
            }

            return RedirectToAction("Movies", "Movie");
        }
    }
}
