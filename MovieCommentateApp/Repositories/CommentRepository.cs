using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Data;
using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Mappers;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(CommentDto commentDto)
        {
            var model = commentDto.CommentDtoToComment();
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model == null)
                return null;
            _context.Remove(model);
            return model;
        }

        public async Task<List<Comment>> GetAllAsync(int movieId)
        {
            var list = await _context.Comments
                .Where(x => x.MovieId==movieId)
                .ToListAsync();
            return list;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var model = await _context.Comments.FindAsync(id);
            return model;
        }
    }
}
