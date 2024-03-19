namespace MovieReviewApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int MovieId { get; set; } 
        public string Text { get; set; } =string.Empty;
        public int Rating { get; set; }
        public Movie Movie { get; set; }
        public AppUser AppUser { get; set; }
    }
}