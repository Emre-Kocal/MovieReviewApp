using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Data;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Mappers;
using MovieReviewApp.Models;
using System.Linq;

namespace MovieReviewApp.Areas.Admin.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> CreateAsync(CreateActorDto createActorDto)
        {
            var model = createActorDto.CreateActorToActor();
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Actor?> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model == null)
                return null;
            _context.Actors.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<List<Actor>> GetAllAsyncExceptFor(int movieId)
        {
            var actorList = await _context
                .Actors
                .Include(x=>x.Movies)
                .ToListAsync();

            var filteredActors = actorList
                .Where(actor => actor.Movies
                .All(movie => movie.MovieId != movieId))
                .ToList();

            return filteredActors;
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            var model = await _context.Actors.FindAsync(id);
            return model;
        }

        public async Task<Actor?> GetByIdWithAllAsync(int id)
        {
            var model = await _context.Actors
                .Include(x => x.Movies)
                .ThenInclude(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }

        public async Task<Actor?> UpdateAsync(UpdateActorDto updateActorDto)
        {
            var model = await GetByIdAsync(updateActorDto.Id);
            if (model == null)
                return null;
            model.FullName = updateActorDto.FullName;
            model.BirthDate = updateActorDto.BirthDate;
            model.Nationality = updateActorDto.Nationality;
            model.Image = updateActorDto.Image;
            model.Bio = updateActorDto.Bio;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
