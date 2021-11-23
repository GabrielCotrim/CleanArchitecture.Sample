using CleanArchitecture.Sample.Domain.Entities;

namespace CleanArchitecture.Sample.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(int productId);

        Task DeleteProductById(int productId);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(int productId, Product product);
    }
}
