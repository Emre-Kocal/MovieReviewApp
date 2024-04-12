using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserDto>> GetListAsync();
        public Task<List<UserDto>> GetListAsync(string filter);
        public Task<UserDto?> GetByIdAsync(string id);
    }
}