using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConestogaInsidersClub.Data
{
    public class Seeder
    {
        static GameGenre genre;
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
            SeedGameGenres();
            SeedPreferences();
            SeedGames();
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

            var adminId = "e0e5e08e-96be-4927-9fc1-c1b355a11abc";
            var userId = "d889434c-de0e-495e-b23e-6f855dc942d7";
            user = new ApplicationUser
            {
                Id = userId,
                FirstName = "Regular",
                LastName = "User",
                Email = "user@example.com",
                UserName = "user",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };
            user.PasswordHash = hasher.HashPassword(user, "Qweqwe1!");

            admin = new ApplicationUser
            {
                Id = adminId,
                FirstName = "Super",
                LastName = "Admin",
                Email = "admin@example.com",
                UserName = "admin",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Qweqwe1!");

            context.Users.Add(user);
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

        private static void SeedGameGenres()
        {
            genre = new GameGenre
            {
                Name = "Indie"
            };
            
            context.Add(genre);
            context.SaveChanges();
        }

        private static void SeedPreferences()
        {
            context.Add(new Preference
            {
                Genre = genre.Name,
                Platform = "Windows",
                UserId = user.Id
            });
            context.SaveChanges();
        }

        private static void SeedGames()
        {
            var game = new Game
            {
                Name = "Portal",
                Description = "Teleporting game",
                Price = 12.5,
                Genre = genre.Name
            };

            context.Add(game);
            context.SaveChanges();
            
        }

        private static void ClearDatabase()
        {
            context.RemoveRange(context.Preferences);
            context.RemoveRange(context.GameGenres);
            context.RemoveRange(context.Games);
            context.RemoveRange(context.UserRoles);
            context.RemoveRange(context.Users);
            context.RemoveRange(context.Roles);
        }
    }
}
