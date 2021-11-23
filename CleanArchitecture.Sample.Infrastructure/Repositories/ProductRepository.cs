using CleanArchitecture.Sample.Application.Interfaces.Repositories;
using CleanArchitecture.Sample.Application.Utils;
using CleanArchitecture.Sample.Application.Utils.Exceptions;
using CleanArchitecture.Sample.Domain.Entities;
using CleanArchitecture.Sample.Infrastructure.Data;

namespace CleanArchitecture.Sample.Infrastructure.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _dbContext;
        public ProductRepository(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            else throw new NotFoundException();
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                return product;
            }
            
            throw new NotFoundException();
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(_dbContext.Products.ToList());
        }

        public async Task<Product> UpdateProduct(int productId, Product productUpdate)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                product.Name = productUpdate.Name;
                product.Description = productUpdate.Description;
                product.Price = productUpdate.Price;
                product.Stock = productUpdate.Stock;
                product.UpdatedAt = DateUtil.GetCurrentDate();

                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();

                return product;
            }

            throw new NotFoundException();
        }
    }
}
