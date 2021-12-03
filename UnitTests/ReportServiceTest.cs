using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    class ReportServiceTest : TestBase
    {

        [OneTimeSetUp]
        public async Task BeforeAll()
        {

            using var context = new ApplicationDbContext(ContextOptions);

            var genre = await SeedEntities(new GameGenre
            {
                Name = "Indie"
            });

            var testGames = await SeedEntities(
                new Game()
                {
                    GameId = 1,
                    Name = "Age of Empires IV",
                    Description = "RTS Game",
                    GenreName = genre.Name
                },
                new Game()
                {
                    GameId = 2,
                    Name = "Assassin's Creed Unity",
                    Description = "Action game",
                    GenreName = genre.Name

                });


            var testUser = await SeedEntities(
                new ApplicationUser()
                {
                    Id = "d125",
                    UserName = "test",
                    NormalizedUserName = "TEST",
                    Email = "test@user.com",
                    Preference = new Preference()
                    {
                        Platform = "PS4"
                    }
                }
            );

            List<CartItem> cartItems = await SeedEntities(
                new CartItem
                {
                    GameId = testGames[0].GameId,
                    UserId = testUser.Id
                },
                new CartItem
                {
                    GameId = testGames[1].GameId,
                    UserId = testUser.Id
                });

            var orderItem = new List<OrderItem>
            {
                new OrderItem
                {
                    GameId = testGames[0].GameId
                },
                new OrderItem
                {
                    GameId = testGames[1].GameId
                }
            };

            Order order1 = await SeedEntities(
                new Order
                {
                    UserId = testUser.Id,
                    CreatedAt = DateTime.Now,
                    OrderItems = orderItem
                });
            var test = context.Orders.Include(o => o.OrderItems).ToList();

        }

        [Test, Order(1)]
        public async Task OrdersReport_GetTodaysOrders()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReportService(context);
            //Act
            var orders = await service.OrdersReport(DateTime.Now);
            //Assert
            Assert.IsNotNull(orders);
            Assert.That(orders, Has.Count.EqualTo(1));
            Assert.That(orders[0].OrderItems, Has.Count.EqualTo(2));
        }

        [Test, Order(2)]
        public async Task GamesAndWishlistReport_GetGamesAndTheirWishlistCount()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReportService(context);
            //Act
            var games = await service.GamesAndWishlistReport();
            //Assert
            Assert.IsNotNull(games);
            Assert.That(games, Has.Count.EqualTo(2));
            Assert.That(games[0].WishedItems, Has.Count.EqualTo(0));
            Assert.That(games[1].WishedItems, Has.Count.EqualTo(0));

        }

        [Test, Order(3)]
        public async Task UsersReport_GetAllUsers()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReportService(context);
            //Act
            var users = await service.CustomerInfoReport();
            //Assert
            Assert.IsNotNull(users);
            Assert.That(users, Has.Count.EqualTo(1));

        }

        [Test, Order(4)]
        public async Task PlatformReport_GetPlatformCount()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReportService(context);
            //Act
            var users = await service.PlatformReport();
            //Assert
            Assert.IsNotNull(users);
            Assert.That(users, Has.Count.EqualTo(1));

        }
    }
}
