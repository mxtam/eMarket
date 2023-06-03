using eMarket.Models;

namespace eMarket.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShopingCartItem> items,string userId,string userEmail);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task CancelOrder(int id);
    }
}
