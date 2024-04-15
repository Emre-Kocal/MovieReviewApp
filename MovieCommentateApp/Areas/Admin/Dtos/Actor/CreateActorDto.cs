using MovieReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Areas.Admin.Dtos.Actor
{
    public class CreateActorDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Full Name must be 4 characters")]
        [MaxLength(280, ErrorMessage = "Full Name cannot be over 280 characters")]
        public string FullName { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Nationality { get; set; } = string.Empty;
        [MaxLength(280, ErrorMessage = "Full Name cannot be over 1000 characters")]
        public string? Bio { get; set; } = string.Empty;
    }
}
