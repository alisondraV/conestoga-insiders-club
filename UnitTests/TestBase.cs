using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.Models;
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

            using var context = new ApplicationDbContext(ContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }

        protected async Task<ApplicationUser> SeedUser(string userName)
        {
            using var context = new ApplicationDbContext(ContextOptions);
            var user = new ApplicationUser
            {
                UserName = userName
            };
                await context.Set<ApplicationUser>().AddAsync(user);

            await context.SaveChangesAsync();

            return user;
        }
    }
}
