using MovieReviewApp.Models;

namespace MovieReviewApp.Dtos.Movie
{
    public class MovieAllDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public List<ActorMovie> Actors { get; set; } = new List<ActorMovie>();
        public string PosterImage { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
