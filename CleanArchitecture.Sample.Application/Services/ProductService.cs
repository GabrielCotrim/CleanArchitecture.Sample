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

        public Product CreateProduct(Product product)
        {
            return _repository.CreateProduct(product);
        }

        public void DeleteProductById(int productId)
        {
            _repository.DeleteProductById(productId);
        }

        public Product GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }

        public List<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Product UpdateProduct(int productId, Product product)
        {
            return _repository.UpdateProduct(productId, product);
        }
    }
}
