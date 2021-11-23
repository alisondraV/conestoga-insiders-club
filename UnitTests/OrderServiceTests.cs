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
    class OrderServiceTests : TestBase
    {
        private Game testGame;
        private GameGenre testGenre;
        private Order testOrder;
        private ApplicationUser user;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            testGenre = new GameGenre
            {
                Name = "Indie"
            };

            testGame = await SeedEntities(
                new Game
                {
                    GameId = 1,
                    Name = "Age of Empires IV",
                    Description = "RTS Game",
                    Genre = testGenre
                });

            user = new ApplicationUser()
            {
                UserName = "test",
            };

            testOrder = await SeedEntities<Order>(
                new Order
                {
                    User = user,
                }
            );

            await context.SaveChangesAsync();
        }

        [Test, Order(1)]
        public async Task AddOrderItem_ShouldAddAnOrderItem()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new OrderService(context);
            var expectedOrderItem = new OrderItem
            {
                GameId = testGame.GameId,
                OrderId = testOrder.OrderId
            };

            //Act
            await service.AddOrderItem(expectedOrderItem);
            var actualOrderItem = await context.OrderItems.FirstOrDefaultAsync();
            
            //Assert
            Assert.IsNotNull(actualOrderItem);
            Assert.AreEqual(expectedOrderItem.GameId, actualOrderItem.GameId);
            Assert.AreEqual(expectedOrderItem.OrderId, actualOrderItem.OrderId);
        }

        [Test, Order(2)]
        public async Task GetOrders_ShouldGetAllOrdersForUser()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new OrderService(context);
            var otherOrder = await SeedEntities(new Order
            {
                User = new ApplicationUser
                {
                    UserName = "Bar"
                },
                OrderStatus = OrderStatus.Pending,
                OrderType = OrderType.Online
            });

            //Act
            var orders = await service.GetOrders(user.Id);

            //Assert
            Assert.That(orders, Has.Count.EqualTo(1));
            Assert.IsFalse(orders.Any(o => o.OrderId == otherOrder.OrderId));
        }

        [Test, Order(3)]
        public async Task CreateOrderFromCartItems_CreatesAnOrderFromCartItems()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new OrderService(context);
            var cartItems = await SeedEntities(
                new CartItem
                {
                    Game = new Game
                    {
                        GenreName = testGenre.Name,
                        Name = "foo"
                    },
                    UserId = user.Id
                },
                new CartItem
                {
                    Game = new Game
                    {
                        GenreName = testGenre.Name,
                        Name = "bar"
                    },
                    UserId = user.Id
                }
            );

            //Act
            var order = await service.CreateOrderFromCartItems(cartItems);
            
            //Assert
            Assert.That(order.OrderItems, Has.Count.EqualTo(cartItems.Count));
        }
    }
}
