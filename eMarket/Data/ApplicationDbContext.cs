using eMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text.RegularExpressions;

namespace eMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ShopingCartItem> ShopingCartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}



