using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface ICartService
    {
        Task AddCartItem(CartItem item);
        Task<List<CartItem>> GetCartItems(string userId);
        Task RemoveCartItem(CartItem item);
        Task<int> GetCartCount(string userId);

    }
}
