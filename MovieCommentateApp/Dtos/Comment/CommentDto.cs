using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Comment
{
    public class CommentDto
    {
        public string UserId { get; set; } = string.Empty;
        public int MovieId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Comment must be 3 characters")]
        [MaxLength(500, ErrorMessage = "Comment cannot be over 500 characters")]
        public string Text { get; set; } = string.Empty;
        [Required]
        public int Rating { get; set; }
    }
}
