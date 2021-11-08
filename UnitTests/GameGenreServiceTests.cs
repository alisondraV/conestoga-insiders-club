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
    public class GameGenreServiceTests : TestBase
    {
        public List<GameGenre> expectedGenres;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            expectedGenres = await SeedEntities(new GameGenre
            {
                Name = "Horror"
            },
            new GameGenre
            {
                Name = "Indie"
            });
        }

        [Test, Order(1)]
        public async Task GetGameGenres_ShouldListAllGameGenres()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new GameGenreService(context);

            // Act
            var actualGenres = await service.GetGameGenres();

            // Assert
            Assert.NotNull(actualGenres);
            Assert.That(actualGenres, Has.Count.EqualTo(expectedGenres.Count));
        }
    }
}