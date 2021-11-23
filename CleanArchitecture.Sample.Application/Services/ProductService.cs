using CleanArchitecture.Sample.Application.Interfaces.Repositories;
using CleanArchitecture.Sample.Application.Interfaces.Services;
using CleanArchitecture.Sample.Domain.Entities;

namespace CleanArchitecture.Sample.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> CreateProduct(Product product)
        {
            return _repository.CreateProduct(product);
        }

        public Task DeleteProductById(int productId)
        {
            return _repository.DeleteProductById(productId);
        }

        public Task<Product> GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }

        public Task<List<Product>> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Task<Product> UpdateProduct(int productId, Product product)
        {
            return _repository.UpdateProduct(productId, product);
        }
    }
}
