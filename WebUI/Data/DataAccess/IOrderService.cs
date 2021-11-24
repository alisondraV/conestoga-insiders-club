using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IOrderService
    {
        Task AddOrderItem(OrderItem item);
        Task<List<Order>> GetOrders(string userId);
        Task<List<Order>> GetOrders();
        Task<Order> CreateOrderFromCartItems(List<CartItem> cartItems, OrderType orderType = OrderType.Online);
        Task MarkAsProcessed(Order order);
        Task<List<Game>> GetOrderedGames(string userId);
    }
}