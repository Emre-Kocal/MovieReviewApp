using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<ActorMovie> Movies { get; set; } = new List<ActorMovie>();
    }
}
