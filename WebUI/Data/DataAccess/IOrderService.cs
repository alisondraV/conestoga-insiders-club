using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IOrderService
    {
        Task AddOrderItem(OrderItem item);
        Task<List<Order>> GetOrders(string userId);
        Task CreateOrderFromCartItems(List<CartItem> cartItems);
    }
}