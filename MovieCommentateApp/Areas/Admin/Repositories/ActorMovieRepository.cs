using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Areas.Admin.Dtos.ActorMovie;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Repositories
{
    public class ActorMovieRepository : IActorMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorMovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ActorMovieDto actorMovie)
        {
            await _context.ActorMovies.AddAsync(actorMovie.ActorMovieToCreateDto());
            await _context.SaveChangesAsync();
        }

        public async Task<ActorMovie?> DeleteAsync(ActorMovieDto actorMovie)
        {
            var model = await GetByIdAsync(actorMovie);
            if (model == null)
            {
                return null;
            }
            _context.ActorMovies.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Actor>> GetAllByMovieAsync(int movieId)
        {
            var list=await _context.ActorMovies
                .Where(x=>x.MovieId == movieId)
                .Include(x=>x.Actor)
                .Select(x=>x.Actor)
                .ToListAsync();
            return list;
        }

        public async Task<ActorMovie?> GetByIdAsync(ActorMovieDto actorMovie)
        {
            var model=await _context.ActorMovies
                .FirstOrDefaultAsync(x => x.MovieId == actorMovie.MovieId &&
                x.ActorId == actorMovie.ActorId);
            return model;
        }
    }
}
