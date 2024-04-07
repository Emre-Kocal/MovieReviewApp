using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Dtos.Account;
using MovieReviewApp.Migrations;
using MovieReviewApp.Models;
using System.Linq;
using System.Runtime.InteropServices;
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Username not found and/or password incorrect");
                return View();
            }

            var result = await _signInManager
                .PasswordSignInAsync(loginDto.Username,loginDto.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username not found and/or password incorrect");
                return View();
            }
            return RedirectToAction("Movies", "Movie");
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
                return View();
            }
            var existingEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError(string.Empty, "The email is already in use.");
                return View();
            }

            var existingUser = await _userManager.FindByNameAsync(registerDto.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "The username is already in use.");
                return View();
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
                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}
