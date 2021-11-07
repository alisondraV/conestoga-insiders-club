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

        protected async Task<List<T>> SeedEntities<T>(params T[] entities) where T : class
        {
            foreach (var entity in entities)
            {
                await SeedEntities(entity);
            }

            return entities.ToList();
        }

        protected async Task<T> SeedEntities<T>(T entity) where T : class
        {
            using var context = new ApplicationDbContext(ContextOptions);

            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
