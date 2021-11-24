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
            return context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Order> CreateOrderFromCartItems(List<CartItem> cartItems, OrderType orderType = OrderType.Online)
        {
            var order = new Order
            {
                UserId = cartItems.First().UserId,
                CreatedAt = DateTime.Now,
                OrderType = orderType
            };
            await context.AddAsync(order);

            order.OrderStatus = order.OrderType == OrderType.Online
                ? OrderStatus.Processed
                : OrderStatus.Pending;

            order.OrderItems = cartItems
                .Select(c => new OrderItem { GameId = c.GameId })
                .ToList();

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
