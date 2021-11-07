using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__addresse__5CF1C59A90B364F3");

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.Province).IsUnicode(false);

                entity.HasOne(d => d.UserIdNavigation)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_addresses");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                    .HasName("PK__cart_ite__B30FD466E5616F1B");

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_cart_items");

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_cart_items");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.HasKey(e => new { e.UserId1, e.UserId2 })
                    .HasName("PK__friendsh__2EA53AFBF202847F");

                entity.Property(e => e.UserId1).IsUnicode(true);

                entity.Property(e => e.UserId2).IsUnicode(true);

                entity.HasOne(d => d.UserId1Navigation)
                    .WithMany(p => p.FriendshipUserId1Navigations)
                    .HasForeignKey(d => d.UserId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_friendships");

                entity.HasOne(d => d.UserId2Navigation)
                    .WithMany(p => p.FriendshipUserId2Navigations)
                    .HasForeignKey(d => d.UserId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_friendships1");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Genre).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_genres_TO_games");
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__game_gen__72E12F1AB1253DCF");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_orders");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GameId })
                    .HasName("PK__order_it__A9A773D52B4E4CFD");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_order_items");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_TO_order_items");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__preferen__5CF1C59A3E97A739");

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.GenreName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_genres_TO_preferences");

                entity.HasOne(d => d.FavouriteGame)
                    .WithMany(g => g.Preferences)
                    .HasForeignKey(d => d.FavouriteGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_TO_preferences");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                    .HasName("PK__reviews__B30FD466087C2256");

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_reviews");

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_reviews");
            });

            modelBuilder.Entity<WishedItem>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                    .HasName("PK__wished_i__B30FD466E0DD1830");

                entity.Property(e => e.UserId).IsUnicode(true);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.WishedItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_wished_items");

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.WishedItems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_wished_items");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
