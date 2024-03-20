﻿using MovieReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Dtos.Movie
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Max 100 character")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(5000, ErrorMessage = "Max 5000 character")]
        public string Description { get; set; } = string.Empty;
        [Range(1,10000)]
        public int Year { get; set; }
        public string PosterImage { get; set; } = string.Empty;
        public int GenreId { get; set; }
    }
}
