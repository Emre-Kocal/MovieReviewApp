using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetAllAsync();
        public Task<List<Movie>> GetAllAsync(QueryMovieDto query);
        public Task<Movie?> GetByIdAsync(int id);
        public Task<Movie?> GetByIdWithAllAsync(int id);
        public Task<Movie> CreateAsync(CreateMovieDto createMovieDto);
        public Task<Movie?> UpdateAsync(int id, UpdateMovieDto updateMovieDto);
        public Task<Movie?> DeleteAsync(int id);
    }
}
