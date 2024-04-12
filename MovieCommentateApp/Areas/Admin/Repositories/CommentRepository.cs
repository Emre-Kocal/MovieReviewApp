using Microsoft.AspNetCore.Identity;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CommentRepository(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Delete(int id)
        {
            var model = await GetByIdAsync(id);
            if (model == null)
            {
                //return error
            }
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var model = await _context.Comments.FindAsync(id);
            return model;
        }

        public async Task<string?> GetUsersIdAsync(int id)
        {
            var model = await GetByIdAsync(id);
            return model.UserId;

        }
    }
}
