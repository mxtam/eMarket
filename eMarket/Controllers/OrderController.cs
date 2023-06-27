using eMarket.Data.Cart;
using eMarket.Data.Services;
using eMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using eMarket.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ShopingCart _shopingCart;

        public OrderController(IProductService productService, IOrderService orderService, ShopingCart shopingCart) 
        {
            _productService= productService;
            _orderService= orderService;
            _shopingCart= shopingCart;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        [Authorize]
        public IActionResult ShopingCart()
        {
            var items = _shopingCart.GetShopingCartItems();
            _shopingCart.ShopingCartItems = items;

            var response = new ShopingCartViewModel()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShopingCart(int id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _shopingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShopingCart));
        }

        public async Task<IActionResult> RemoveItemFromShopingCart(int id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _shopingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShopingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shopingCart.GetShopingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items,userId,userEmail);
            await _shopingCart.ClearShopingCartAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> CancelOrder(int id)
        { 
            await _orderService.CancelOrder(id);

            return RedirectToAction("Index");
        }
    }
}
