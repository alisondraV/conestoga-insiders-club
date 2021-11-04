﻿// <auto-generated />
using System;
using ConestogaInsidersClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConestogaInsidersClub.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Address", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<string>("Address1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("address2");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Province")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("province");

                    b.HasKey("UserId")
                        .HasName("PK__addresse__5CF1C59A90B364F3");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.CartItem", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.HasKey("UserId", "GameId")
                        .HasName("PK__cart_ite__B30FD466E5616F1B");

                    b.HasIndex("GameId");

                    b.ToTable("cart_items");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Friendship", b =>
                {
                    b.Property<string>("UserId1")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id1");

                    b.Property<string>("UserId2")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.HasKey("UserId1", "UserId2")
                        .HasName("PK__friendsh__2EA53AFBF202847F");

                    b.HasIndex("UserId2");

                    b.ToTable("friendships");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("genre");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.HasKey("GameId");

                    b.HasIndex("Genre");

                    b.ToTable("games");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.GameGenre", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.HasKey("Name")
                        .HasName("PK__game_gen__72E12F1AB1253DCF");

                    b.ToTable("game_genres");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quantity")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("OrderId", "GameId")
                        .HasName("PK__order_it__A9A773D52B4E4CFD");

                    b.HasIndex("GameId");

                    b.ToTable("order_items");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Preference", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("FavouriteGameId")
                        .HasColumnType("int")
                        .HasColumnName("favourite_game_id");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("genre");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("platform");

                    b.Property<bool>("ReceivePromotionalEmails")
                        .HasColumnType("bit")
                        .HasColumnName("receive_promotional_emails");

                    b.HasKey("UserId")
                        .HasName("PK__preferen__5CF1C59A3E97A739");

                    b.HasIndex("FavouriteGameId");

                    b.HasIndex("GenreName");

                    b.ToTable("preferences");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Review", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit")
                        .HasColumnName("approved");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("description");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint")
                        .HasColumnName("rating");

                    b.HasKey("UserId", "GameId")
                        .HasName("PK__reviews__B30FD466087C2256");

                    b.HasIndex("GameId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.WishedItem", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.HasKey("UserId", "GameId")
                        .HasName("PK__wished_i__B30FD466E0DD1830");

                    b.HasIndex("GameId");

                    b.ToTable("wished_items");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Address", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserIdNavigation")
                        .WithOne("Address")
                        .HasForeignKey("ConestogaInsidersClub.Data.Models.Address", "UserId")
                        .HasConstraintName("FK_users_TO_addresses")
                        .IsRequired();

                    b.Navigation("UserIdNavigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.CartItem", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.Game", "Game")
                        .WithMany("CartItems")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_games_TO_cart_items")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserIdNavigation")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_users_TO_cart_items")
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("UserIdNavigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Friendship", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserId1Navigation")
                        .WithMany("FriendshipUserId1Navigations")
                        .HasForeignKey("UserId1")
                        .HasConstraintName("FK_users_TO_friendships")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserId2Navigation")
                        .WithMany("FriendshipUserId2Navigations")
                        .HasForeignKey("UserId2")
                        .HasConstraintName("FK_users_TO_friendships1")
                        .IsRequired();

                    b.Navigation("UserId1Navigation");

                    b.Navigation("UserId2Navigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Game", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.GameGenre", "GenreNavigation")
                        .WithMany("Games")
                        .HasForeignKey("Genre")
                        .HasConstraintName("FK_game_genres_TO_games")
                        .IsRequired();

                    b.Navigation("GenreNavigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Order", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_users_TO_orders")
                        .IsRequired();

                    b.Navigation("UserIdNavigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.OrderItem", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.Game", "Game")
                        .WithMany("OrderItems")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_games_TO_order_items")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_orders_TO_order_items")
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Preference", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.Game", "FavouriteGame")
                        .WithMany("Preferences")
                        .HasForeignKey("FavouriteGameId")
                        .HasConstraintName("FK_game_TO_preferences")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.GameGenre", "Genre")
                        .WithMany("Preferences")
                        .HasForeignKey("GenreName")
                        .HasConstraintName("FK_game_genres_TO_preferences")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "User")
                        .WithOne("Preference")
                        .HasForeignKey("ConestogaInsidersClub.Data.Models.Preference", "UserId")
                        .HasConstraintName("FK_users_TO_preferences")
                        .IsRequired();

                    b.Navigation("FavouriteGame");

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Review", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_games_TO_reviews")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserIdNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_users_TO_reviews")
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("UserIdNavigation");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.WishedItem", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.Game", "Game")
                        .WithMany("WishedItems")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_games_TO_wished_items")
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", "UserIdNavigation")
                        .WithMany("WishedItems")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_users_TO_wished_items")
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("UserIdNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ConestogaInsidersClub.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("CartItems");

                    b.Navigation("FriendshipUserId1Navigations");

                    b.Navigation("FriendshipUserId2Navigations");

                    b.Navigation("Orders");

                    b.Navigation("Preference");

                    b.Navigation("Reviews");

                    b.Navigation("WishedItems");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Game", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");

                    b.Navigation("Preferences");

                    b.Navigation("Reviews");

                    b.Navigation("WishedItems");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.GameGenre", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("ConestogaInsidersClub.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
