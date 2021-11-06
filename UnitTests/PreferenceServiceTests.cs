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
        GameGenre otherGenre;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            var genre = new GameGenre
            {
                Name = "Indie"
            };

            otherGenre = await SeedEntities(new GameGenre
            {
                Name = "Horror"
            });

            var game = new Game
            {
                Name = "Portal"
            };

            preference = new Preference
            {
                FavouriteGame = game,
                Genre = genre,
                Platform = "Windows",
                ReceivePromotionalEmails = false
            };

            user = new ApplicationUser
            {
                UserName = "Foo",
                Preference = preference
            };

            await SeedEntities(user);

            await context.SaveChangesAsync();
        }

        [Test, Order(1)]
        public async Task GetPreference_GetsThePreferenceByUsername()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new PreferenceService(context, new UserService(context));

            // Act
            var actualPreference = await service.GetPreference(user.UserName);

            // Assert
            Assert.AreEqual(preference.UserId, actualPreference.UserId);
            Assert.AreEqual(preference.Platform, actualPreference.Platform);
            Assert.AreEqual(preference.FavouriteGameId, actualPreference.FavouriteGameId);
            Assert.AreEqual(preference.FavouriteGame.Name, actualPreference.FavouriteGame.Name);
            Assert.AreEqual(preference.GenreName, actualPreference.GenreName);
        }

        [Test, Order(2)]
        public async Task UpdatePreference_SetsNewPropertiesOnAPreference()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new PreferenceService(context, new UserService(context));
            var expectedPlatform = "Ubuntu";
            var expectedReceivePromoEmails = true;

            // Act
            preference.Genre = otherGenre;
            preference.Platform = expectedPlatform;
            preference.ReceivePromotionalEmails = expectedReceivePromoEmails;
            await service.UpdatePreference(preference);
            var actualPreference = await context.Preferences.AsNoTracking().Include(p => p.Genre).FirstOrDefaultAsync();

            // Assert
            Assert.AreEqual(otherGenre.Name, actualPreference.GenreName);
            Assert.AreEqual(expectedPlatform, actualPreference.Platform);
            Assert.AreEqual(expectedReceivePromoEmails, actualPreference.ReceivePromotionalEmails);
        }
    }
}