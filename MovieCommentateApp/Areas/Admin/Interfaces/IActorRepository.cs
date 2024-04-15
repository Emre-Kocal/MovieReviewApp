using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface IActorRepository
    {
        public Task<List<Actor>> GetAllAsync();
        public Task<Actor?> GetByIdAsync(int id);
        public Task<Actor?> GetByIdWithAllAsync(int id);
        public Task<Actor> CreateAsync(CreateActorDto createActorDto);
        public Task<Actor?> UpdateAsync(UpdateActorDto updateActorDto);
        public Task<Actor?> DeleteAsync(int id);
    }
}
