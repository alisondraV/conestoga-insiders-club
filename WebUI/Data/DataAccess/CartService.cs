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
            return await context.CartItems.Where(a => a.UserId == userId).CountAsync();
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
