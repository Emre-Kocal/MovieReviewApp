using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Mappers
{
    public static class MovieMappers
    {
        public static Movie ToMovieFromCreateDto(this CreateMovieDto model)
        {
            return new Movie
            {
                Name = model.Name,
                Description = model.Description,
                PosterImage = model.PosterImage,
                Year = model.Year,
                GenreId = model.GenreId

            };
        }
    }
}
