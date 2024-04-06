using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;

namespace MovieReviewApp.Data.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors");
            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.FullName).HasColumnName("full_name");
            builder.Property(a => a.Image).HasColumnName("image");
            builder.Property(a => a.BirthDate).HasColumnName("birth_date");
            builder.Property(a => a.Nationality).HasColumnName("nationality");
            builder.Property(a => a.Bio).HasColumnName("bio");
        }
    }
}
