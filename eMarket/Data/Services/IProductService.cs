using eMarket.Data.ViewModels;
using eMarket.Models;

namespace eMarket.Data.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(ProductViewModel vm);
        Task UpdateAsync(int id, ProductViewModel vm);
        Task DeleteAsync(int id);
    }
}
