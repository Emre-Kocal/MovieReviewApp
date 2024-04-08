using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync(int movieId);
        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(CommentDto commentDto);
        public Task<Comment?> DeleteAsync(int id);
    }
}
