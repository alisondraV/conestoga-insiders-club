using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    class CartServiceTest : TestBase
    {
        private Game testGame;
        private Game testGame2;
        private ApplicationUser testUser;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {

            using var context = new ApplicationDbContext(ContextOptions);

            testGame = new Game()
            {
                GameId = 1,
                Name = "Age of Empires IV",
                Description = "RTS Game"
            };
            await context.Set<Game>().AddAsync(testGame);

            testGame2 = new Game()
            {
                GameId = 2,
                Name = "Assassin's Creed Unity",
                Description = "Action game"
            };
            await context.Set<Game>().AddAsync(testGame2);

            testUser = new ApplicationUser()
            {
                Id = "d123",
                UserName = "test",
                NormalizedUserName = "TEST",
                Email = "test@user.com",
            };
            await context.Set<ApplicationUser>().AddAsync(testUser);

            CartItem cartItem = new CartItem { GameId = testGame.GameId, UserId = testUser.Id };
            await context.Set<CartItem>().AddAsync(cartItem);

            await context.SaveChangesAsync();
        }

        [Test, Order(1)]
        public async Task GetCartItems()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new CartService(context);

            // Act
            var cart = await service.GetCartItems(testUser.Id);

            // Assert
            Assert.NotNull(cart);
            Assert.That(cart, Has.Count.EqualTo(1));
        }

        [Test, Order(2)]
        public async Task AddItemToCart()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new CartService(context);
            CartItem cartItem = new CartItem()
            {
                GameId = testGame2.GameId,
                UserId = testUser.Id
            };
            // Act
            await service.AddCartItem(cartItem);
            var cart = await service.GetCartItems(testUser.Id);

            // Assert
            Assert.NotNull(cart);
            Assert.That(cart, Has.Count.EqualTo(2));
        }

        [Test, Order(3)]
        public async Task GetCartItemCount()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new CartService(context);

            // Act
            var cartCount = await service.GetCartCount(testUser.Id);

            // Assert
            Assert.AreEqual(cartCount, 2);
        }

        [Test, Order(4)]
        public async Task DeleteCartItems()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new CartService(context);
            CartItem cartItem = new CartItem { GameId = testGame.GameId, UserId = testUser.Id };
            CartItem cartItem2 = new CartItem()
            {
                GameId = testGame2.GameId,
                UserId = testUser.Id
            };
            // Act
            await service.RemoveCartItem(cartItem);
            await service.RemoveCartItem(cartItem2);
            var cart = service.GetCartItems(testUser.Id);
            // Assert
            Assert.NotNull(cart);
            Assert.False(cart.Result.Any());
        }

    }
}
