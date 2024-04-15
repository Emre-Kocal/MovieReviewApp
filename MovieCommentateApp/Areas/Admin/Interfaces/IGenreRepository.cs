using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Areas.Admin.Dtos.Genre;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetAllAsync();
        public Task<Genre?> GetByIdAsync(int id);
        public Task<Genre?> GetByIdWithAllAsync(int id);
        public Task<Genre> CreateAsync(CreateGenreDto createGenreDto);
        public Task<Genre?> StatusChangeAsync(int id);
    }
}
