using MovieReviewApp.Areas.Admin.Dtos.ActorMovie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Interfaces
{
    public interface IActorMovieRepository
    {
        public Task<List<Actor>> GetAllByMovieAsync(int movieId);
        public Task<ActorMovie> GetByIdAsync(ActorMovieDto actorMovie);
        public Task CreateAsync(ActorMovieDto actorMovie);
        public Task<ActorMovie?> DeleteAsync(ActorMovieDto actorMovie);
    }
}
