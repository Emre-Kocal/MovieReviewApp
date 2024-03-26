using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetAllAsync();
        public Task<Genre?> GetByIdAsync(int id);
    }
}
