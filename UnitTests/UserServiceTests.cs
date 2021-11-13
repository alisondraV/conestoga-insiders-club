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
    public class UserServiceTests : TestBase
    {
        public List<ApplicationUser> expectedUsers;
        public List<Card> expectedCards;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            var address = new Address
            {
                Address1 = "1 King St."
            };

            expectedUsers = await SeedEntities(
                new ApplicationUser()
                {
                    UserName = "Foo",
                    MailingAddress = address,
                },
                new ApplicationUser()
                {
                    UserName = "Bar"
                }
            );
        }

        [Test, Order(1)]
        public async Task GetUsers_ShouldListAllUsers()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);

            // Act
            var actualUsers = await service.GetUsers();

            // Assert
            Assert.NotNull(actualUsers);
            Assert.That(actualUsers, Has.Count.EqualTo(expectedUsers.Count));
        }

        [Test, Order(2)]
        public async Task GetUser_ShouldGetAUserByUsername()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var expectedUser = expectedUsers[0];
            var otherUser = expectedUsers[1];

            // Act
            var actualUser = await service.GetUser(expectedUser.UserName);

            // Assert
            Assert.NotNull(actualUser);
            Assert.AreEqual(actualUser.UserName, expectedUser.UserName);
            Assert.AreNotEqual(actualUser.UserName, otherUser.UserName);
        }

        [Test, Order(3)]
        public async Task UpdateUser_UpdatesAnExistingUser()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var targetUser = expectedUsers.First();
            var newUserName = "Zoo";

            // Act
            targetUser.UserName = newUserName;
            await service.UpdateUser(targetUser);
            var updatedUser = await context.Users.FindAsync(targetUser.Id);

            // Assert
            Assert.AreEqual(newUserName, updatedUser.UserName);
        }

        [Test, Order(3)]
        public async Task UpdateUser_UpdatesTheAddressOfAnExistingUser()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var targetUser = expectedUsers.First();
            var expectedAddress1 = "1 Queen St.";

            // Act
            targetUser.MailingAddress.Address1 = expectedAddress1;
            await service.UpdateUser(targetUser);
            var updatedUser = await context.Users.FindAsync(targetUser.Id);

            // Assert
            Assert.AreEqual(expectedAddress1, updatedUser.MailingAddress.Address1);
        }

        [Test, Order(4)]
        public async Task CreateFriendship_CreatesAFriendshipBetween2Users()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var firstUser = expectedUsers.First();
            var secondUser = expectedUsers.ElementAt(1);

            // Act
            await service.CreateFriendship(firstUser.Id, secondUser.Id);

            // Assert
            var friendships = await context.Friendships.ToListAsync();
            Assert.That(friendships, Has.Count.EqualTo(1));
            var friendship = friendships.First();
            Assert.AreEqual(friendship.UserId1, firstUser.Id);
            Assert.AreEqual(friendship.UserId2, secondUser.Id);
            Assert.NotNull(friendship.CreatedAt);
        }

        [Test, Order(5)]
        public async Task GetFriends_ListsAllUsersThatAreFriendsWithTheUserInQuestion()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var firstUser = expectedUsers.First();
            var secondUser = expectedUsers.ElementAt(1);

            // Act
            var actualFriends = await service.GetFriends(firstUser);

            // Assert
            Assert.That(actualFriends, Has.Count.EqualTo(1));
            Assert.AreEqual(secondUser.UserName, actualFriends.First().UserName);
        }

        [Test, Order(6)]
        public async Task DeleteFriendship_RemovesAnExistingFriendship()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var firstUser = expectedUsers.First();
            var secondUser = expectedUsers.ElementAt(1);

            // Act
            await service.DeleteFriendship(firstUser.Id, secondUser.Id);

            // Assert
            var friendships = await context.Friendships.ToListAsync();
            Assert.IsEmpty(friendships);
        }

        [Test, Order(7)]
        public async Task GetCards_ListsAllCreditCardsThatTheUserHas()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var targetUser = expectedUsers.First();

            expectedCards = await SeedEntities(new Card
            {
                UserId = targetUser.Id,
            },
            new Card
            {
                UserId = targetUser.Id
            });

            // Act
            var actualCards = await service.GetCards(targetUser.Id);

            // Assert
            Assert.That(actualCards, Has.Count.EqualTo(expectedCards.Count));
            Assert.IsTrue(actualCards.All(c => c != null));
        }

        [Test, Order(8)]
        public async Task DeleteCard_DeletesACreditCard()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var targetCard = await context.Cards.FirstOrDefaultAsync();

            // Act
            await service.DeleteCard(targetCard);
            var actualCards = await context.Cards.ToListAsync();

            // Assert
            Assert.That(actualCards, Has.Count.EqualTo(expectedCards.Count - 1));
        }

        [Test, Order(9)]
        public async Task DeleteCard_DeletesACreditCardAndDoesNotDeleteARelatedUser()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new UserService(context);
            var targetCard = await context.Cards.FirstOrDefaultAsync();
            var numberOfUsers = await context.Users.CountAsync();

            // Act
            await service.DeleteCard(targetCard);
            var newNumberOfUsers = await context.Users.CountAsync();

            // Assert
            Assert.AreEqual(numberOfUsers, newNumberOfUsers);
        }
    }
}