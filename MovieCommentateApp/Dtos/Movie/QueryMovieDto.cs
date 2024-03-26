namespace MovieReviewApp.Dtos.Movie
{
    public class QueryMovieDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int GenreId { get; set; } = 0;
        public int Year { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }
}
