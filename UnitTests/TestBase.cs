using ConestogaInsidersClub.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    public class TestBase
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        public TestBase()
        {
            ContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "testing")
                .EnableSensitiveDataLogging()
                .Options;
            Seed();
        }

        private void Seed()
        {
            using var context = new ApplicationDbContext(ContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}
