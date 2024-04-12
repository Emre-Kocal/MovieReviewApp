using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface ICommentRepository
    {
        public Task Delete(int id);
        public Task<Comment?> GetByIdAsync(int id);
        public Task<string?> GetUsersIdAsync(int id);
    }
}
