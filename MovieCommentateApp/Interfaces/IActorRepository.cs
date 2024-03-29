using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IActorRepository
    {
        public Task<Actor?> GetByIdAsync(int id);
    }
}
