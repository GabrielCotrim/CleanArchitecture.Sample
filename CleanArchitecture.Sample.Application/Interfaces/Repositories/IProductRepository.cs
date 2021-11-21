using CleanArchitecture.Sample.Domain.Entities;

namespace CleanArchitecture.Sample.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product GetProductById(int productId);

        void DeleteProductById(int productId);

        Product CreateProduct(Product product);

        Product UpdateProduct(int productId, Product productUpdate);
    }
}
