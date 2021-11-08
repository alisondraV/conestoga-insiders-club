﻿using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConestogaInsidersClub.Data
{
    public class Seeder
    {
        static GameGenre genre;
        static Game game;
        static Address address;
        static ApplicationDbContext context;
        static IdentityRole adminRole;
        static IdentityRole userRole;
        static ApplicationUser user;
        static ApplicationUser admin;

        public static void Seed(ApplicationDbContext context)
        {
            Seeder.context = context;
            ClearDatabase();
            SeedUserRoles();
            SeedApplicationUsers();
            SeedAddresses();
            SeedGameGenres();
            SeedGames();
            SeedPreferences();
        }

        private static void SeedUserRoles()
        {
            adminRole = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            userRole = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            };

            context.Add(adminRole);
            context.Add(userRole);

            context.SaveChanges();
        }

        private static void SeedApplicationUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var userId = "d889434c-de0e-495e-b23e-6f855dc942d7";
            var secondUserId = "a789434c-de0e-495e-c67e-c1b215a11abc";
            var adminId = "e0e5e08e-96be-4927-9fc1-c1b355a11abc";

            user = new ApplicationUser
            {
                Id = userId,
                UserName = "user",
                NormalizedUserName = "USER",
                FirstName = "Regular",
                LastName = "User",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "2136547890",
                PhoneNumberConfirmed = true,
                BirthDay = System.DateTime.Now.AddYears(-25),
                Address = address
            };
            user.PasswordHash = hasher.HashPassword(user, "Qweqwe1!");

            var secondUser = new ApplicationUser
            {
                Id = secondUserId,
                UserName = "JaD",
                NormalizedUserName = "JAD",
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jdoe@example.com",
                NormalizedEmail = "JDOE@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                BirthDay = System.DateTime.Now.AddYears(-20),
                Address = address
            };
            secondUser.PasswordHash = hasher.HashPassword(user, "Abcqwe1!");

            admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FirstName = "Super",
                LastName = "Admin",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "1299947890",
                PhoneNumberConfirmed = true,
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Qweqwe1!");

            context.Users.Add(user);
            context.Users.Add(secondUser);
            context.Users.Add(admin);
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = userRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = adminId,
                RoleId = adminRole.Id
            });
            context.SaveChanges();
        }

        private static void SeedAddresses()
        {
            address = new Address
            {
                UserId = user.Id,
                Address1 = "123 Main St",
                City = "Kitchener",
                Province = "ON",
                Country = "Canada"
            };

            context.Add(address);
            context.SaveChanges();
        }

        private static void SeedGameGenres()
        {
            genre = new GameGenre
            {
                Name = "Indie"
            };

            context.Add(genre);
            context.SaveChanges();
        }


        private static void SeedGames()
        {
            game = new Game
            {
                Name = "Portal",
                Description = "Teleporting game",
                Price = 12.5,
                Genre = genre.Name
            };

            context.Add(game);
            context.SaveChanges();
        }

        private static void SeedPreferences()
        {
            context.Add(new Preference
            {
                Genre = genre,
                Platform = "Windows",
                ReceivePromotionalEmails = false,
                FavouriteGame = game,
                UserId = user.Id
            });
            context.SaveChanges();
        }

        private static void ClearDatabase()
        {
            context.RemoveRange(context.Preferences);
            context.RemoveRange(context.GameGenres);
            context.RemoveRange(context.Games);
            context.RemoveRange(context.Friendships);
            context.RemoveRange(context.UserRoles);
            context.RemoveRange(context.Addresses);
            context.RemoveRange(context.Users);
            context.RemoveRange(context.Roles);
        }
    }
}
