using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Interfaces;
using ProductService.Models;
using SharedContracts;

namespace ProductService.Services
{
    public class ProductServices : IProductService
    {
        private readonly ProductDbContext _db;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductServices(ProductDbContext db, IPublishEndpoint publishEndpoint)
        {
            _db = db;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            await _publishEndpoint.Publish(new ProductCreatedEvent
            {
                ProductId = product.ID,
                ProductName = product.Name,
                CreatedByUserId = product.CreatedByUserId
            });
            
           
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> UpdateAsync(string id, Product updatedProduct)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return null;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;    
        }
    }
}
