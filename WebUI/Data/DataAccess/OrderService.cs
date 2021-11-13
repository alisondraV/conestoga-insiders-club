using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext context;

        public async Task AddOrderItem(OrderItem item)
        {
            await context.OrderItems.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public Task<List<OrderItem>> GetOrderItems(string userId)
        {
            return context.OrderItems.Where(a => a.Order.UserId == userId).ToListAsync();
        }

        public async Task<Order> CreateOrderFromCartItems(List<CartItem> cartItems)
        {
            return new Order();
        }
    }
}
