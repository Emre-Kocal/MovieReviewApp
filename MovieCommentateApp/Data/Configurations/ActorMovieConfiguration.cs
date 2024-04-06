using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;

namespace MovieReviewApp.Data.Configurations
{
    public class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.ToTable("ActorMovies");
            builder.Property(am => am.ActorId).HasColumnName("actor_id");
            builder.Property(am => am.MovieId).HasColumnName("movie_id");
        }
    }
}
