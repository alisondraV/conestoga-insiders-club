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
    public class PreferenceServiceTests : TestBase
    {
        Preference preference;
        ApplicationUser user;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            user = await SeedEntities(new ApplicationUser
            {
                UserName = "Foo"
            });

            var genre = await SeedEntities(new GameGenre
            {
                Name = "Indie"
            });

            var game = new Game
            {
                Name = "Portal"
            };

            var preferences = await context.Preferences.ToListAsync();
            preference = await SeedEntities(new Preference
            {
                UserId = user.Id,
                FavouriteGame = game,
                GenreName = genre.Name,
                Platform = "Windows",
                ReceivePromotionalEmails = false
            });

            user.Preference = preference;
            context.Update(user);
            await context.SaveChangesAsync();
        }

        [Test, Order(1)]
        public async Task GetPreference_GetsThePreferenceByUsername()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new PreferenceService(context, new UserService(context));

            // Act
            var users = await context.Users.ToListAsync();
            var actualPreference = await service.GetPreference(user.UserName);

            // Assert
            Assert.AreEqual(actualPreference.UserId, preference.UserId);
            Assert.AreEqual(actualPreference.Platform, preference.Platform);
        }
    }
}