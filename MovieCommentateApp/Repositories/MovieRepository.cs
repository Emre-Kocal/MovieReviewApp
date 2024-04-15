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

        public async Task<Movie> CreateAsync(CreateMovieDto createMovieDto)
        {
            var model = createMovieDto.CreateDtoToMovie();
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model == null)
                return null;
            _context.Remove(model);
            return model;
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
            return await list.ToListAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(x => x.Genre)
                .Where(x => x.Genre.Status)
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var model = await _context.Movies
                .Include(x => x.Genre)
                .Where(x => x.Genre.Status)
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
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

        public async Task<Movie?> UpdateAsync(int id, UpdateMovieDto updateMovieDto)
        {
            var model = await _context.Movies.FindAsync(id);
            if (model == null)
                return null;
            model.Name = updateMovieDto.Name;
            model.Description = updateMovieDto.Description;
            model.Year = updateMovieDto.Year;
            model.PosterImage = updateMovieDto.PosterImage;
            model.GenreId = updateMovieDto.GenreId;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
