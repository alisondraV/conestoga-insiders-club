using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext context;

        public CartService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddCartItem(CartItem item)
        {
            await context.CartItems.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task<int> GetCartCount(string userId)
        {
            List<CartItem> items = await context.CartItems.Where(a => a.UserId == userId.ToString()).ToListAsync();
            int total = items.Count();
            return total;
        }

        public Task<List<CartItem>> GetCartItems(string userId)
        {
            return context.CartItems.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task RemoveCartItem(CartItem item)
        {
            context.CartItems.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
