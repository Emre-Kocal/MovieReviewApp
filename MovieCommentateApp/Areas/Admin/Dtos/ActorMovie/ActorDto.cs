namespace MovieReviewApp.Areas.Admin.Dtos.ActorMovie
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
    }
}
