﻿namespace MovieReviewApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public bool Status { get; set; } = true;
    }
}
