using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }=string.Empty;
        public int MovieId { get; set; } 
        public string Text { get; set; } =string.Empty;
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public Movie Movie { get; set; }
        public AppUser User { get; set; }
    }
}