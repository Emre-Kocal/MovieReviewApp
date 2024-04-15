using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Areas.Admin.Dtos.Genre;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateAsync(CreateGenreDto createGenreDto)
        {
            var model = createGenreDto.CreateGenreToGenre();
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres
                .Include(x=>x.Movies)
                .OrderBy(x=>x.Name)
                .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            var model = await _context.Genres.FindAsync(id);
            return model;
        }

        public async Task<Genre?> GetByIdWithAllAsync(int id)
        {
            var model = await _context.Genres
                .Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }

        public async Task<Genre?> StatusChangeAsync(int id)
        {
            var model=await GetByIdAsync(id);
            if (model==null)
            {
                return null;
            }

            if (model.Status) 
                model.Status = false;
            else 
                model.Status = true;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
