using CleanArchitecture.Sample.Application.DTOs.Requests;
using CleanArchitecture.Sample.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Sample.Application.Interfaces.ApplicationServices
{
    public interface IProductApplicationService
    {
        List<ProductResponse> GetProducts();

        ProductResponse GetProductById(int productId);

        void DeleteProductById(int productId);

        ProductResponse CreateProduct(CreateProductRequest product);

        ProductResponse UpdateProduct(int productId, UpdateProductRequest product);
    }
}
