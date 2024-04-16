using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Username must be 3 characters")]
        [MaxLength(50, ErrorMessage = "Username cannot be over 50 characters")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters")]
        [MaxLength(30, ErrorMessage = "Password cannot be over 30 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
