using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class WishedItemService : IWishedItemService
    {
        private ApplicationDbContext context;
        public WishedItemService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Game>> GetWishedGamesForUser(string userId)
        {
            return context.WishedItems
             .Where(w => w.UserId == userId)
             .Select(w => w.Game)
             .ToListAsync();
        }

        public async Task AddToWishlist(Game game, string userId)
        {
            context.WishedItems.Add(new WishedItem
            {
                GameId = game.GameId,
                UserId = userId
            });
            await context.SaveChangesAsync();
        }

        public Task RemoveFromWishlist(Game game, string userId)
        {
            throw new NotImplementedException();
        }

        public Task AddOrRemoveFromWishlist(Game game, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
