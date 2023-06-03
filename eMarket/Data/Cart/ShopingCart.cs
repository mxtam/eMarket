using eMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Data.Cart
{
    public class ShopingCart
    {
        public ApplicationDbContext _context { get; set; }

        public string ShopingCartId { get; set; }
        public List<ShopingCartItem> ShopingCartItems { get; set; }

        public ShopingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static ShopingCart GetShopingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShopingCart(context) { ShopingCartId = cartId };
        }

        public void AddItemToCart(Product product)
        {
            var shopingCartItem = _context.ShopingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShopingCartId == ShopingCartId);

            if (shopingCartItem == null)
            {
                shopingCartItem = new ShopingCartItem()
                {
                    ShopingCartId = ShopingCartId,
                    Product = product,
                    Amount = 1
                };

                _context.ShopingCartItems.Add(shopingCartItem);
            }
            else
            {
                shopingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var shopingCartItem = _context.ShopingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShopingCartId == ShopingCartId);

            if (shopingCartItem != null)
            {
                if (shopingCartItem.Amount > 1)
                {
                    shopingCartItem.Amount--;
                }
                else
                {
                    _context.ShopingCartItems.Remove(shopingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShopingCartItem> GetShopingCartItems()
        {
            return ShopingCartItems ?? (ShopingCartItems = _context.ShopingCartItems.Where(n => n.ShopingCartId == ShopingCartId).Include(n => n.Product).ToList());
        }

        public double GetShopingCartTotal() => _context.ShopingCartItems.Where(n => n.ShopingCartId == ShopingCartId).Select(n => n.Product.Price * n.Amount).Sum();

        public async Task ClearShopingCartAsync()
        {
            var items = await _context.ShopingCartItems.Where(n => n.ShopingCartId == ShopingCartId).ToListAsync();
            _context.ShopingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
