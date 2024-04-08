namespace MovieReviewApp.Dtos.Comment
{
    public class CommentDto
    {
        public string UserId { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
