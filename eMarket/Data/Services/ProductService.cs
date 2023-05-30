using eMarket.Data.ViewModels;
using eMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace eMarket.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) 
        {
            _context= context;
        }

        public async Task CreateAsync(ProductViewModel vm)
        {
            Product product = new Product { Name = vm.Name, Description = vm.Description, Price = vm.Price };

            if (vm.Photo != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(vm.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)vm.Photo.Length);
                }
                product.Photo = imageData;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await  _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        public async Task UpdateAsync(int id, ProductViewModel vm)
        {
            var product = await GetByIdAsync(id);

            product.Name = vm.Name;
            product.Description = vm.Description;
            product.Price = vm.Price;

            if (vm.Photo != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(vm.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)vm.Photo.Length);
                }
                product.Photo = imageData;
            }
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

        }
    }
}
