using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

#nullable disable

namespace ConestogaInsidersClub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameGenre> GameGenres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<WishedItem> WishedItems { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            // runs all configurations (classes that implement IEntityTypeConfiguration<T>)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
