using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;
using System.Reflection.Emit;

namespace MovieReviewApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            builder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(am => am.ActorId);

            builder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(am => am.MovieId);

            base.OnModelCreating(builder);

        }
    }
}
