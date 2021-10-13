using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class aspnetConestogaInsidersClub3A8BC16ACA9A402793414149D242BA13Context : DbContext
    {
        public aspnetConestogaInsidersClub3A8BC16ACA9A402793414149D242BA13Context()
        {
        }

        public aspnetConestogaInsidersClub3A8BC16ACA9A402793414149D242BA13Context(DbContextOptions<aspnetConestogaInsidersClub3A8BC16ACA9A402793414149D242BA13Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameGenre> GameGenres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
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
                entity.HasKey(e => e.Nickname)
                    .HasName("PK__addresse__5CF1C59A90B364F3");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.Province).IsUnicode(false);

                entity.HasOne(d => d.NicknameNavigation)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.Nickname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_addresses");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.Nickname, e.GameId })
                    .HasName("PK__cart_ite__B30FD466E5616F1B");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_cart_items");

                entity.HasOne(d => d.NicknameNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Nickname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_cart_items");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.HasKey(e => new { e.Nickname1, e.Nickname2 })
                    .HasName("PK__friendsh__2EA53AFBF202847F");

                entity.Property(e => e.Nickname1).IsUnicode(false);

                entity.Property(e => e.Nickname2).IsUnicode(false);

                entity.HasOne(d => d.Nickname1Navigation)
                    .WithMany(p => p.FriendshipNickname1Navigations)
                    .HasForeignKey(d => d.Nickname1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_friendships");

                entity.HasOne(d => d.Nickname2Navigation)
                    .WithMany(p => p.FriendshipNickname2Navigations)
                    .HasForeignKey(d => d.Nickname2)
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

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.HasOne(d => d.NicknameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Nickname)
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
                entity.HasKey(e => e.Nickname)
                    .HasName("PK__preferen__5CF1C59A3E97A739");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.Property(e => e.Genre).IsUnicode(false);

                entity.Property(e => e.Platform).IsUnicode(false);

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_genres_TO_preferences");

                entity.HasOne(d => d.NicknameNavigation)
                    .WithOne(p => p.Preference)
                    .HasForeignKey<Preference>(d => d.Nickname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_preferences");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.Nickname, e.GameId })
                    .HasName("PK__reviews__B30FD466087C2256");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_reviews");

                entity.HasOne(d => d.NicknameNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Nickname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_reviews");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Nickname)
                    .HasName("PK__users__5CF1C59ADF43945B");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<WishedItem>(entity =>
            {
                entity.HasKey(e => new { e.Nickname, e.GameId })
                    .HasName("PK__wished_i__B30FD466E0DD1830");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.WishedItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_games_TO_wished_items");

                entity.HasOne(d => d.NicknameNavigation)
                    .WithMany(p => p.WishedItems)
                    .HasForeignKey(d => d.Nickname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_TO_wished_items");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
