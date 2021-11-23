using System;
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
        private IUserService userService;

        public OrderService(ApplicationDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService=userService;
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

        public Task<List<Order>> GetOrders()
        {
            return context.Orders.Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> CreateOrderFromCartItems(List<CartItem> cartItems)
        {
            var order = new Order
            {
                UserId = cartItems.First().UserId,
                CreatedAt = DateTime.Now
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
            return order;
        }

        public async Task MarkAsProcessed(Order order)
        {
            order.OrderStatus = OrderStatus.Processed;
            await context.SaveChangesAsync();
        }

        public Task<List<Game>> GetOrderedGames(string userId)
        {
            return context.OrderItems
                .Where(oi => oi.Order.UserId == userId)
                .Select(oi => oi.Game)
                .ToListAsync();
        }
    }
}
