using ProductService.Models;

namespace ProductService.Interfaces
{

    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product?> UpdateAsync(string id, Product product);
        Task<bool> DeleteAsync(string id);
    }

}
