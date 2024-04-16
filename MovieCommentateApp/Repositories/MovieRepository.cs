using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewApp.Data;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Mappers;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var list = await _context.Movies
                .Include(x=>x.Genre)
                .Where(x=>x.Genre.Status)
                .ToListAsync();
            return list;
        }
        public async Task<List<Movie>> GetAllAsync(QueryMovieDto query)
        {
            var list = _context.Movies
                .Include(x=>x.Genre)
                .Where(x=>x.Genre.Status)
                .AsQueryable();

            if (!query.Name.IsNullOrEmpty())
                list = list.Where(x => x.Name.ToLower().Contains(query.Name.ToLower()));

            if (query.Year != 0)
                list = list.Where(x => x.Year == query.Year);

            if (query.GenreId != 0)
                list = list.Where(x => x.GenreId == query.GenreId);

            if (list.Count()>=query.PageSize*(query.PageNumber-1))
            {
                list = list
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize);
            }
            else
            {
                return new List<Movie>();
            }
            return await list.ToListAsync();
        }
        public async Task<Movie?> GetByIdWithAllAsync(int id)
        {
            var model = await _context.Movies
                .Include(x => x.Genre)
                .Include(x => x.Actors)
                .ThenInclude(x => x.Actor)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Where(x => x.Genre.Status)
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }
    }
}
