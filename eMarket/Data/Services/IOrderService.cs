using eMarket.Models;
using eMarket.Data.ViewModels;

namespace eMarket.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShopingCartItem> items,string userId,string userEmail, OrderViewModel ordervm);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task CancelOrder(int id);
    }
}
