using MovieReviewApp.Areas.Admin.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class MovieMapper
    {
        public static Movie CreateDtoToMovie(this CreateMovieDto model)
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
