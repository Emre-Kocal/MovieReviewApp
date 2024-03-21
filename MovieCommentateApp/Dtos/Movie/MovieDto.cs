using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Movie
{
    public class MovieDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public string PosterImage { get; set; } = string.Empty;
        public int GenreId { get; set; }
    }
}
