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
    public class WishedItemServiceTests : TestBase
    {
        public List<WishedItem> expectedWishedItems;
        public ApplicationUser user;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            user = await SeedEntities(new ApplicationUser
            {
                UserName = "Foo"
            });

            expectedWishedItems = await SeedEntities(new WishedItem
            {
                UserId = user.Id,
                Game = new Game
                {
                    GameId = 1,
                    Name = "Portal"
                }
            }, new WishedItem
            {
                UserId = user.Id,
                Game = new Game
                {
                    GameId = 2,
                    Name = "GTA"
                }
            });
        }

        [Test, Order(1)]
        public async Task GetWishedGamesForUser_ListsAllGamesThatAreWishedByTheUser()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new WishedItemService(context);

            // Act
            var actualGames = await service.GetWishedGamesForUser(user.Id);

            // Assert
            Assert.That(actualGames, Has.Count.EqualTo(expectedWishedItems.Count));
            for (int i = 0; i < actualGames.Count; i++)
            {
                Assert.AreEqual(expectedWishedItems[i].Game.Name, actualGames[i].Name);
            }
        }

        [Test, Order(2)]
        public async Task AddToWishlist_ShouldAddAGameToTheUsersWishlist()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new WishedItemService(context);
            var game = await SeedEntities(new Game
            {
                Name = "CS:GO"
            });

            // Act
            await service.AddToWishlist(game, user.Id);
            var actualWishedItems = await service.GetWishedGamesForUser(user.Id);

            // Assert
            Assert.That(actualWishedItems, Has.Count.EqualTo(expectedWishedItems.Count + 1));
        }
    }
}