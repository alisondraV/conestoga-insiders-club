using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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

        [Test, Order(1)]
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

        [Test, Order(2)]
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

        [Test, Order(3)]
        public async Task SearchGame_ShouldListGamesContainingTheQueryRegardlessOfTheCase()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var query = "foo";

            // Act
            var searchResults = await service.SearchGames(query);

            // Assert
            Assert.That(searchResults, Has.Count.EqualTo(1));
            foreach (var result in searchResults)
            {
                Assert.That(result.Name.ToLower(), Contains.Substring(query));
            }
        }

        [Test, Order(4)]
        public async Task AddGame_AddsANewGame()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var newGame = new Game
            {
                Name = "qwer",
                Description = "Some description",
                Genre = genre.Name
            };

            // Act
            await service.AddGame(newGame);
            var allGames = await context.Games.ToListAsync();

            // Assert
            Assert.That(allGames, Has.Count.EqualTo(3));
        }

        [Test, Order(5)]
        public async Task UpdateGame_UpdatesAnExistingGame()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var targetGameId = 1;
            var newGame = new Game
            {
                GameId = targetGameId,
                Name = "qwer",
                Description = "Some description",
                Genre = genre.Name
            };

            // Act
            await service.UpdateGame(newGame);
            var targetGame = await context.Games.FindAsync(targetGameId);

            // Assert
            Assert.AreEqual(newGame.Name, targetGame.Name);
        }

        [Test, Order(6)]
        public async Task DeleteGame_DeletesAGame()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var targetGameId = 1;
            var targetGame = await context.Games.FindAsync(targetGameId);

            // Act
            await service.DeleteGame(targetGame);
            var allGames = await context.Games.ToListAsync();

            // Assert
            Assert.That(allGames, Has.Count.EqualTo(2));
            var ids = allGames.Select(g => g.GameId);
            Assert.That(ids, Has.No.Member(targetGameId));
        }

        [Test, Order(7)]
        public async Task AddToWishlist_AddsTheGameToTheUsersWishlist()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameService(context);
            var targetGame = expectedGames.First();

            var user = await SeedEntities(new ApplicationUser
            {
                UserName = "Foo"
            });

            // Act
            await service.AddToWishlist(targetGame, user.Id);
            var wishedItems = await context.WishedItems.Where(w => w.UserId == user.Id).ToListAsync();

            // Assert
            Assert.That(wishedItems, Has.Count.EqualTo(1));
            Assert.AreEqual(targetGame.GameId, wishedItems.First().GameId);
        }
    }
}