using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;

namespace MovieReviewApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.Property(m => m.Name).HasColumnName("name");
            builder.Property(m => m.Description).HasColumnName("description");
            builder.Property(m => m.Year).HasColumnName("year");
            builder.Property(m => m.PosterImage).HasColumnName("poster_image");
            builder.Property(m => m.GenreId).HasColumnName("genre_id");
        }
    }
}
