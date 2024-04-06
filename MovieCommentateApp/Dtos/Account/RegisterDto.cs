using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
