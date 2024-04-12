using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto?> GetByIdAsync(string id)
        {
            var user = await _userManager.Users
                .Include(x => x.Comments)
                .ThenInclude(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return null;
            return user.AppUserToUserDto();
        }

        public async Task<List<UserDto>> GetListAsync()
        {
            return await _userManager.Users
                .Include(x => x.Comments)
                .Select(x => x.AppUserToUserDto())
                .ToListAsync();
        }

        public async Task<List<UserDto>> GetListAsync(string filter)
        {
            return await _userManager.Users
                .Include(x => x.Comments)
                .Where(x => x.UserName.Contains(filter))
                .Select(x => x.AppUserToUserDto())
                .ToListAsync();
        }
    }
}
