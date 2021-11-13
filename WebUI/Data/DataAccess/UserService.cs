using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<ApplicationUser>> GetUsers()
        {
            return context.Users.ToListAsync();
        }

        public Task<ApplicationUser> GetUser(string userName)
        {
            return context.Users
                .Where(u => u.UserName == userName)
                .SingleAsync();
        }

        public Task<ApplicationUser> GetUserWithRelatedData(string userName)
        {
            return context.Users
                .Where(u => u.UserName == userName)
                .Include(u => u.Preference)
                .ThenInclude(p => p.FavouriteGame)
                .Include(u => u.MailingAddress)
                .Include(u => u.ShippingAddress)
                .Include(u => u.Cards)
                .SingleAsync();
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task CreateFriendship(string userId1, string userId2)
        {
            await context.Friendships.AddAsync(new Friendship
            {
                UserId1 = userId1,
                UserId2 = userId2,
                CreatedAt = System.DateTime.Now
            });
            await context.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> GetFriends(ApplicationUser user)
        {
            var friendships = await context.Friendships.Where(f => f.UserId1 == user.Id || f.UserId2 == user.Id).ToListAsync();
            var friendIds = friendships.Select(f => f.UserId1 == user.Id ? f.UserId2 : f.UserId1);
            return await context.Users.Where(u => friendIds.Contains(u.Id)).ToListAsync();
        }

        public async Task DeleteFriendship(string userId1, string userId2)
        {
            var friendship = await context.Friendships.FirstOrDefaultAsync(f => f.UserId1 == userId1 && f.UserId2 == userId2);
            context.Friendships.Remove(friendship);
            await context.SaveChangesAsync();
        }

        public async Task<List<Card>> GetCards(string userId)
        {
            var user = await context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user.Cards.ToList();
        }

        public async Task DeleteCard(Card card)
        {
            context.Remove(card);
            await context.SaveChangesAsync();
        }
    }
}
