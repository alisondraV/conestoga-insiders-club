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

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddOrderItem(OrderItem item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public Task<List<Order>> GetOrders(string userId)
        {
            return context.Orders.Include(o => o.OrderItems)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task CreateOrderFromCartItems(List<CartItem> cartItems)
        {
            var order = new Order
            {
                UserId = cartItems.First().UserId,
            };
            await context.AddAsync(order);

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    GameId = cartItem.GameId,
                };
                order.OrderItems.Add(orderItem);
            }

            await context.SaveChangesAsync();
        }
    }
}
