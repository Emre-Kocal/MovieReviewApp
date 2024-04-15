using MovieReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Areas.Admin.Dtos.Genre
{
    public class CreateGenreDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Genre name must be 3 characters")]
        [MaxLength(50, ErrorMessage = "Genre name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
