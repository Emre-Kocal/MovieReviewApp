using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _context.Actors
                .Include(x=>x.Movies)
                .ThenInclude(x=>x.Movie)
                .FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
