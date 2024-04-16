using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetAllAsync();
        public Task<List<Movie>> GetAllAsync(QueryMovieDto query);
        public Task<Movie?> GetByIdWithAllAsync(int id);
    }
}
