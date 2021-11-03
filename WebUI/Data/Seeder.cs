using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Data
{
    public class Seeder
    {
        static GameGenre genre;
        static ApplicationDbContext context;

        public static void Seed(ApplicationDbContext context)
        {
            Seeder.context = context;
            SeedGameGenres();
            SeedGames();
        }

        private static void SeedGameGenres()
        {
            context.RemoveRange(context.GameGenres);
            genre = new GameGenre
            {
                Name = "Indie"
            };
            
            context.Add(genre);
            context.SaveChanges();
        }

        private static void SeedGames()
        {
            context.RemoveRange(context.Games);
            var game = new Game
            {
                Name = "Portal",
                Description = "Teleporting game",
                Price = 12.5,
                Genre = genre.Name
            };

            context.Add(game);
            context.SaveChanges();
            
        }
    }
}
