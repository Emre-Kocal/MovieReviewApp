using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;

namespace MovieReviewApp.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.Property(c => c.UserId).HasColumnName("user_id");
            builder.Property(c => c.MovieId).HasColumnName("movie_id");
            builder.Property(c => c.Text).HasColumnName("text");
            builder.Property(c => c.Rating).HasColumnName("rating");
            builder.Property(c => c.Date).HasColumnName("date");
        }
    }
}
