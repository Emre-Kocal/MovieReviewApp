using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Movie
{
    public class QueryMovieDto
    {
        [Required]
        [Range(1,100)]
        public int PageNumber { get; set; } = 1;
        [Required]
        public int PageSize { get; set; } = 12;
        public int? GenreId { get; set; } = 0;
        public int? Year { get; set; } = 0;
        [MaxLength(30, ErrorMessage = "Max 30 characters")]
        public string? Name { get; set; } = string.Empty;
    }
}
