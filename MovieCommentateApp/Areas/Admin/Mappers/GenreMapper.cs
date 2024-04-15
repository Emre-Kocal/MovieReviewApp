
using MovieReviewApp.Areas.Admin.Dtos.Genre;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class GenreMapper
    {
        public static Genre CreateGenreToGenre(this CreateGenreDto genre)
        {
            return new Genre
            {
                Name = genre.Name,
                Status = genre.Status,
            };
        }
    }
}
