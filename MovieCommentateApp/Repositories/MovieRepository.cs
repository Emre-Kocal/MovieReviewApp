using Microsoft.EntityFrameworkCore;
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
            var model=createMovieDto.CreateDtoToMovie();
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model==null)
                return null;
            _context.Remove(model);
            return model;
        }

        public async Task<List<Movie>> GetAllAsync(FilterMovieDto filterMovieDto)
        {
            var list = _context.Movies.AsQueryable();

            return await list.ToListAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var model=await _context.Movies.FindAsync(id);
            if (model == null)
                return null;
            return model;
        }

        public async Task<MovieAllDto?> GetByIdWithAllAsync(int id)
        {
            var model = await _context.Movies
                .Include(x => x.Genre)
                .Include(x => x.Actors)
                .ThenInclude(x=>x.Actor)
                .Include(x=>x.Comments)
                .FirstOrDefaultAsync(x=>x.Id==id);
            if (model == null)
                return null;
            var modeldto = model.MovieToMovieAllDto();
            return modeldto;
        }

        public async Task<Movie?> UpdateAsync(int id, UpdateMovieDto updateMovieDto)
        {
            var model = await _context.Movies.FindAsync(id);
            if (model==null)
                    return null;
            model.Name=updateMovieDto.Name;
            model.Description=updateMovieDto.Description;
            model.Year=updateMovieDto.Year;
            model.PosterImage=updateMovieDto.PosterImage;
            model.GenreId=updateMovieDto.GenreId;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
