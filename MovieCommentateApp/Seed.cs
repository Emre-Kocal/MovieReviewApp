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
            if (_context.Movies.Any(x => x.Id > 0))
                return;
            var genres = new List<Genre>
                {
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Drama" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Sci-Fi" },
                    new Genre { Name = "Adventure" },
                    new Genre { Name = "Biography" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Mystery" }
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
                new Movie { Name = "Interstellar", Year = 2014, GenreId = genres.Single(g => g.Name == "Sci-Fi").Id, Description = "A science fiction film exploring space travel, time dilation, and the survival of humanity on a dying Earth."},
                new Movie { Name = "The Social Network", Year = 2010, GenreId = genres.Single(g => g.Name == "Biography").Id, Description = "A biographical drama about the founding and rise of Facebook and its co-founder Mark Zuckerberg."},
                new Movie { Name = "Inglourious Basterds", Year = 2009, GenreId = genres.Single(g => g.Name == "Action").Id, Description = "A war film depicting a group of Jewish U.S. soldiers plotting to assassinate Nazi leaders in occupied France during World War II."},
                new Movie { Name = "The Prestige", Year = 2006, GenreId = genres.Single(g => g.Name == "Mystery").Id, Description = "A mystery thriller about rival magicians in London at the end of the 19th century, directed by Christopher Nolan."},
                new Movie { Name = "Black Swan", Year = 2010, GenreId = genres.Single(g => g.Name == "Thriller").Id, Description = "A psychological thriller about a ballerina's descent into madness, directed by Darren Aronofsky."},
                new Movie { Name = "The King's Speech", Year = 2010, GenreId = genres.Single(g => g.Name == "Biography").Id, Description = "A historical drama about King George VI's struggle to overcome his speech impediment, directed by Tom Hooper."},
                new Movie { Name = "The Artist", Year = 2011, GenreId = genres.Single(g => g.Name == "Comedy").Id, Description = "A romantic comedy-drama about a silent film star's relationship with a young actress during the transition to talking films."},
                new Movie { Name = "Birdman", Year = 2014, GenreId = genres.Single(g => g.Name == "Drama").Id, Description = "A dark comedy-drama about a washed-up actor attempting a comeback on Broadway, directed by Alejandro González Iñárritu."},
                new Movie { Name = "The Revenant", Year = 2015, GenreId = genres.Single(g => g.Name == "Adventure").Id, Description = "An adventure drama about a frontiersman's quest for survival and revenge in the American wilderness, directed by Alejandro González Iñárritu."},
            };

            _context.Movies.AddRange(movies);
            _context.SaveChanges();

            var comments = new List<Comment>
                {
                    new Comment { MovieId = movies.Single(m => m.Name == "Interstellar").Id, Text = "Amazing visuals and emotional depth.", Rating = 5, Date = DateTime.Parse("2024-01-15") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Interstellar").Id, Text = "A masterpiece of science fiction cinema.", Rating = 5, Date = DateTime.Parse("2024-02-05") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Social Network").Id, Text = "Captivating portrayal of tech industry dynamics.", Rating = 4, Date = DateTime.Parse("2024-02-18") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The King's Speech").Id, Text = "Exceptional performances and historical accuracy.", Rating = 4, Date = DateTime.Parse("2024-01-30") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The King's Speech").Id, Text = "A must-watch for history buffs.", Rating = 4, Date = DateTime.Parse("2024-02-22") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The King's Speech").Id, Text = "Inspirational story of overcoming challenges.", Rating = 5, Date = DateTime.Parse("2024-03-10") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Artist").Id, Text = "Unique and charming tribute to silent cinema.", Rating = 4, Date = DateTime.Parse("2024-01-05") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Artist").Id, Text = "Creative storytelling through visuals and music.", Rating = 5, Date = DateTime.Parse("2024-02-17") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Artist").Id, Text = "A delightful cinematic experience.", Rating = 4, Date = DateTime.Parse("2024-03-01") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Birdman").Id, Text = "Intriguing exploration of fame and identity.", Rating = 4, Date = DateTime.Parse("2024-02-08") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Revenant").Id, Text = "Visually stunning with a gripping narrative.", Rating = 5, Date = DateTime.Parse("2024-02-12") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Revenant").Id, Text = "Leonardo DiCaprio's performance is exceptional.", Rating = 5, Date = DateTime.Parse("2024-03-05") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Revenant").Id, Text = "Intense and immersive storytelling.", Rating = 4, Date = DateTime.Parse("2024-03-18") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Black Swan").Id, Text = "Natalie Portman's acting is captivating.", Rating = 5, Date = DateTime.Parse("2024-01-25") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Black Swan").Id, Text = "A dark and mesmerizing psychological thriller.", Rating = 4, Date = DateTime.Parse("2024-02-28") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Inglourious Basterds").Id, Text = "Tarantino's signature style shines through.", Rating = 5, Date = DateTime.Parse("2024-01-10") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Inglourious Basterds").Id, Text = "Brad Pitt delivers a standout performance.", Rating = 4, Date = DateTime.Parse("2024-02-14") },
                    new Comment { MovieId = movies.Single(m => m.Name == "Inglourious Basterds").Id, Text = "A thrilling alternate history war film.", Rating = 4, Date = DateTime.Parse("2024-03-08") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Prestige").Id, Text = "Mind-bending twists and turns.", Rating = 5, Date = DateTime.Parse("2024-02-01") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Prestige").Id, Text = "Hugh Jackman and Christian Bale are outstanding.", Rating = 5, Date = DateTime.Parse("2024-03-15") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "Bad", Rating = 1,Date=DateTime.Parse("2023-12-21") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "Great movie!", Rating = 4,Date=DateTime.Parse("2024-01-02") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Matrix").Id, Text = "One of my all-time favorites.", Rating = 5,Date=DateTime.Parse("2024-02-11") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Godfather").Id, Text = "Mind-bending storyline.", Rating = 4,Date=DateTime.Parse("2024-02-21") },
                    new Comment { MovieId = movies.Single(m => m.Name == "The Godfather").Id, Text = "Classic masterpiece.", Rating = 5,Date=DateTime.Parse("2024-03-02") }
                };
            _context.Comments.AddRange(comments);
            _context.SaveChanges();

            Random rnd = new Random();
            var actorMovies = new List<ActorMovie>();
            for (int i = 0; i < 19; i++)
            {
                var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}; //for 19 movie
                var j = rnd.Next(1, 5);
                for (int k = 0; k < j; k++)
                {
                    var randomNumber = numbers[rnd.Next(0, numbers.Count)];
                    var actorMovie = new ActorMovie
                    {
                        MovieId = movies.Single(m => m.Name == movies[i].Name).Id,
                        ActorId = actors.Single(a => a.FullName == actors[randomNumber].FullName).Id
                    };

                    numbers.Remove(randomNumber);
                    actorMovies.Add(actorMovie);
                }
            }
            _context.ActorMovies.AddRange(actorMovies);
            _context.SaveChanges();
        }
    }
}
