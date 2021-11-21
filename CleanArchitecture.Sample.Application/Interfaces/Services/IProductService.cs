using CleanArchitecture.Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Sample.Application.Interfaces.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProductById(int productId);

        void DeleteProductById(int productId);

        Product CreateProduct(Product product);

        Product UpdateProduct(int productId, Product product);
    }
}
