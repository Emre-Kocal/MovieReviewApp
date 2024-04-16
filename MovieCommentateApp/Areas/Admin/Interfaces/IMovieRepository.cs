using MovieReviewApp.Areas.Admin.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetAllAsync();
        public Task<Movie?> GetByIdAsync(int id);
        public Task<Movie?> GetByIdWithAllAsync(int id);
        public Task<Movie> CreateAsync(CreateMovieDto createMovieDto);
        public Task<Movie?> UpdateAsync(UpdateMovieDto updateMovieDto);
        public Task<Movie?> DeleteAsync(int id);
        public Task<Movie?> ImageAdd(IFormFile imageFile);
        public Task<Movie?> ImageDelete(IFormFile imageFile);
    }
}
