using Microsoft.AspNetCore.Identity;
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
        public DbSet<Genre> Genres { get; set; }
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

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id ="2c5e174e-ab0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id ="2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
            var hasher = new PasswordHasher<IdentityUser>();
            var users = new List<AppUser> {
                new AppUser
                {
                    Id = "8a445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Admin123")
                },
                new AppUser
                {
                    Id = "8a445865-a24d-4543-a6c3-9443d048cdb9", // primary key
                    UserName = "Joshua",
                    NormalizedUserName = "JOSHUA",
                    PasswordHash = hasher.HashPassword(null, "Password2")
                },
                new AppUser
                {
                    Id = "8a445865-a24d-4543-4123-9443d048cdb9", // primary key
                    UserName = "Ellie",
                    NormalizedUserName = "ELLIE",
                    PasswordHash = hasher.HashPassword(null, "Password3")
                }
            };
            builder.Entity<AppUser>().HasData(users);
            var userroles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-ab0e-446f-86af-483d56fd7210",
                    UserId = "8a445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8a445865-a24d-4543-a6c3-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8a445865-a24d-4543-4123-9443d048cdb9"
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userroles);

            base.OnModelCreating(builder);

        }
    }
}
