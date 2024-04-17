using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            await _context.SaveChangesAsync();
            if (model.PosterImage!=null)
                ImageDelete(model.PosterImage);
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

        public string ImageAdd(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img/Movie");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        public void ImageDelete(string imagePath)
        {
            string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/Movie", imagePath);

            if (System.IO.File.Exists(oldFilePath))
                System.IO.File.Delete(oldFilePath);

        }

        public string ImageUpdate(IFormFile imageFile, string oldImagePath)
        {
            var newFileName = ImageAdd(imageFile);
            ImageDelete(oldImagePath);
            return newFileName;
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
