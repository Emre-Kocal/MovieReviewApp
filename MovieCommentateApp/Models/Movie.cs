namespace MovieReviewApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; } 
        public List<ActorMovie> Actors { get; set; } = new List<ActorMovie>();
        public string PosterImage { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Genre Category { get; set; }
    }
}
