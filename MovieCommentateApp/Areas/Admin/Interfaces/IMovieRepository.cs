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
        public string ImageAdd(IFormFile imageFile);
        public string ImageUpdate(IFormFile imageFile , string oldImagePath);
        public void ImageDelete(string imagePath);
    }
}
