using eMarket.Models;
using Microsoft.EntityFrameworkCore;
using eMarket.Data.ViewModels;

namespace eMarket.Data.Services
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShopingCartItem> items,string userId,string userEmail, OrderViewModel ordervm)
        {
            
            Order order = new Order()
            {
                UserId= userId,
                Email= userEmail,
                Phone = ordervm.Phone,
                Name= ordervm.Name,
                LastName = ordervm.LastName,
                Location = ordervm.Location,
                PostOffice = ordervm.PostOffice
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CancelOrder(int id)
        { 
            var order = await _context.Orders.FirstOrDefaultAsync(n => n.Id == id);
            
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
