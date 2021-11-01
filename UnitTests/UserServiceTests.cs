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

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            expectedUsers = new List<ApplicationUser> {
                new ApplicationUser()
                {
                    UserName = "Foo",
                },
                new ApplicationUser()
                {
                    UserName = "Bar"
                },
            };

            foreach (var user in expectedUsers)
            {
                await context.Set<ApplicationUser>().AddAsync(user);
            }

            await context.SaveChangesAsync();
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
    }
}