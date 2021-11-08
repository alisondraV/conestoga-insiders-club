using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IWishedItemService
    {
        Task<List<Game>> GetWishedGamesForUser(string userId);
        Task AddToWishlist(Game game, string userId);
        Task RemoveFromWishlist(Game game, string userId);
        Task AddOrRemoveFromWishlist(Game game, string userId);
    }
}
