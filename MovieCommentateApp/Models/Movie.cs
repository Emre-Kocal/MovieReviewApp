namespace MovieReviewApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; } 
        public string PosterImage { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Comment> Comments { get; set; }= new List<Comment>();
        public List<ActorMovie> Actors { get; set; } = new List<ActorMovie>();
    }
}
