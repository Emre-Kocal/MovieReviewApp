using MovieReviewApp.Data;
using MovieReviewApp.Models;
using System.Diagnostics.Metrics;

namespace MovieReviewApp
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;
        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (_context.Movies.Any(x=>x.Id>0))
                return;
            var genres = new List<Genre>
                {
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Drama" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Sci-Fi" },
                    new Genre { Name = "Adventure" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Animation" }
                };
            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var actors = new List<Actor>
                {
                    new Actor { FullName = "Tom Hanks", BirthDate = new DateTime(1956, 7, 9), Nationality = "American", Bio = "Tom Hanks is a talented actor known for his roles in movies like Forrest Gump and Cast Away." },
                    new Actor { FullName = "Meryl Streep", BirthDate = new DateTime(1949, 6, 22), Nationality = "American", Bio = "Meryl Streep is an award-winning actress known for her versatile performances in various films." },
                    new Actor { FullName = "Leonardo DiCaprio", BirthDate = new DateTime(1974, 11, 11), Nationality = "American", Bio = "Leonardo DiCaprio is a renowned actor known for his roles in movies like Titanic and Inception." },
                    new Actor { FullName = "Scarlett Johansson", BirthDate = new DateTime(1984, 11, 22), Nationality = "American", Bio = "Scarlett Johansson is a talented actress known for her roles in movies like Avengers and Lost in Translation." },
                    new Actor { FullName = "Johnny Depp", BirthDate = new DateTime(1963, 6, 9), Nationality = "American", Bio = "Johnny Depp is an acclaimed actor known for his diverse roles in movies like Pirates of the Caribbean and Edward Scissorhands." },
                    new Actor { FullName = "Angelina Jolie", BirthDate = new DateTime(1975, 6, 4), Nationality = "American", Bio = "Angelina Jolie is a versatile actress known for her roles in movies like Maleficent and Girl, Interrupted." },
                    new Actor { FullName = "Robert Downey Jr.", BirthDate = new DateTime(1965, 4, 4), Nationality = "American", Bio = "Robert Downey Jr. is a charismatic actor known for his portrayal of Iron Man in the Marvel Cinematic Universe." },
                    new Actor { FullName = "Brad Pitt", BirthDate = new DateTime(1963, 12, 18), Nationality = "American", Bio = "Brad Pitt is an award-winning actor known for his roles in movies like Fight Club and Once Upon a Time in Hollywood." },
                    new Actor { FullName = "Emma Stone", BirthDate = new DateTime(1988, 11, 6), Nationality = "American", Bio = "Emma Stone is a talented actress known for her roles in movies like La La Land and The Help." },
                    new Actor { FullName = "Dwayne Johnson", BirthDate = new DateTime(1972, 5, 2), Nationality = "American", Bio = "Dwayne Johnson, also known as The Rock, is an actor and former professional wrestler known for his roles in movies like Jumanji and Fast & Furious." }
                };
            _context.Actors.AddRange(actors);
            _context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie { Name = "The Dark Knight", Year = 2008, GenreId = genres.Single(g => g.Name == "Action").Id, Description = "A film depicting the adventures of Batman, the dark guardian of Gotham City."},
                new Movie { Name = "Inception", Year = 2010, GenreId = genres.Single(g => g.Name == "Sci-Fi").Id, Description = "A science fiction movie about a heist operation using dream-sharing technology."},
                new Movie { Name = "Pulp Fiction", Year = 1994, GenreId = genres.Single(g => g.Name == "Drama").Id, Description = "A Quentin Tarantino film with intersecting stories of various characters."},
                new Movie { Name = "The Lord of the Rings: The Fellowship of the Ring", Year = 2001, GenreId = genres.Single(g => g.Name == "Fantasy").Id, Description = "An epic fantasy film depicting the formation and journey of the Fellowship of the Ring in Middle-earth."},
                new Movie { Name = "The Shawshank Redemption", Year = 1994, GenreId = genres.Single(g => g.Name == "Drama").Id, Description = "A powerful drama about Andy Dufresne's life in Shawshank prison after being wrongly convicted."},
                new Movie { Name = "Forrest Gump", Year = 1994, GenreId = genres.Single(g => g.Name == "Drama").Id, Description = "A drama film depicting the extraordinary life experiences of Forrest Gump, who has an intellectual disability."},
                new Movie { Name = "The Matrix", Year = 1999, GenreId = genres.Single(g => g.Name == "Sci-Fi").Id, Description = "An iconic science fiction film questioning the nature of reality and depicting humanity's fight against machines."},
                new Movie { Name = "Fight Club", Year = 1999, GenreId = genres.Single(g => g.Name == "Drama").Id, Description = "A film starting with an unnamed character joining a secret boxing club called Fight Club, criticizing modern consumer culture."},
                new Movie { Name = "Gladiator", Year = 2000, GenreId = genres.Single(g => g.Name == "Action").Id, Description = "An action-packed historical film about the betrayal and revenge of the legendary Roman general Maximus."},
                new Movie { Name = "The Godfather", Year = 1972, GenreId = genres.Single(g => g.Name == "Action").Id, Description = "An unforgettable crime drama depicting the Corleone family's underworld story from Sicily to America."},
            };

            _context.Movies.AddRange(movies);
            _context.SaveChanges();

            var comments = new List<Comment>
                {
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "Bad", Rating = 1 },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "Great movie!", Rating = 4 },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "One of my all-time favorites.", Rating = 5 },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Godfather").Id, Text = "Mind-bending storyline.", Rating = 4 },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Godfather").Id, Text = "Classic masterpiece.", Rating = 5 }
                };
            _context.Comments.AddRange(comments);
            _context.SaveChanges();

            Random rnd = new Random();
            var actorMovies = new List<ActorMovie>();
            for (int i = 0; i < 10; i++)
            {
                var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var j = rnd.Next(1, 5);
                for (int k = 0; k < j; k++)
                {
                    var randomNumber = numbers[rnd.Next(0, numbers.Count)];
                    var actorMovie = new ActorMovie { MovieId = movies.Single(m => m.Name == movies[i].Name).Id, ActorId = actors.Single(a => a.FullName == actors[randomNumber].FullName).Id };

                    numbers.Remove(randomNumber);
                    actorMovies.Add(actorMovie);
                }
            }
            _context.ActorMovies.AddRange(actorMovies);
            _context.SaveChanges();
        }
    }
}
