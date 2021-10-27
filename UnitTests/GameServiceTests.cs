using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceTests
{
    public class GameServiceTests : TestBase
    {
        public GameGenre genre;
        public List<Game> expectedGames;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            genre = new GameGenre()
            {
                Name = "Horror",
            };
            await context.Set<GameGenre>().AddAsync(genre);

            expectedGames = new List<Game> {
                new Game()
                {
                    GameId = 1,
                    Name = "Foo bar",
                    Description = "Baz Fizz"
                },
                new Game()
                {
                    GameId = 2,
                    Name = "Other bar",
                    Description = "Other Fizz"
                }
            };

            foreach (var game in expectedGames)
            {
                game.Genre = genre.Name;
                await context.Set<Game>().AddAsync(game);
            }

            await context.SaveChangesAsync();
        }

        [Test]
        public async Task GetGames_ShouldListAllGames()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);

            // Act
            var actualGames = await service.GetGames();

            // Assert
            Assert.NotNull(actualGames);
            Assert.That(actualGames, Has.Count.EqualTo(expectedGames.Count));
        }

        [Test]
        public async Task GetGame_ShouldGetAGameById()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var expectedGame = expectedGames[0];
            var otherGame = expectedGames[1];

            // Act
            var actualGame = await service.GetGame(expectedGame.GameId);

            // Assert
            Assert.NotNull(actualGame);
            Assert.AreEqual(actualGame.Name, expectedGame.Name);
            Assert.AreNotEqual(actualGame.Name, otherGame.Name);
        }

        [Test]
        public async Task SearchGame_ShouldListGamesContainingTheQuery()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var query = "Foo";

            // Act
            var searchResults = await service.SearchGames(query);

            // Assert
            Assert.That(searchResults, Has.Count.EqualTo(1));
            foreach (var result in searchResults)
            {
                Assert.That(result.Name, Contains.Substring(query));
            }
        }
    }
}