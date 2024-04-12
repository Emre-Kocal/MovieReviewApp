using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Models;
using MovieReviewApp.Repositories;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var list = await _userRepository.GetListAsync();
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Users(UserDto userDto)
        {
            List<UserDto> list;
            if (userDto.Username.IsNullOrEmpty())
                list = await _userRepository.GetListAsync();
            else
                list = await _userRepository.GetListAsync(userDto.Username);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                //return error
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Users", "User", new {area="Admin"});
        }
    }
}
