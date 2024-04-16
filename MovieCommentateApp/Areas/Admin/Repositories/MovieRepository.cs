using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Areas.Admin.Dtos.Movie;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Repositories
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

        public async Task<List<Movie>> GetAllAsync()
        {
            var list=await _context.Movies
                .Include(x=>x.Comments)
                .ToListAsync();
            return list;
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var model = await _context.Movies
                .Include(x => x.Genre)
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
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }

        public async Task<Movie?> UpdateAsync(UpdateMovieDto updateMovieDto)
        {
            var model = await _context.Movies.FindAsync(updateMovieDto.Id);
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
