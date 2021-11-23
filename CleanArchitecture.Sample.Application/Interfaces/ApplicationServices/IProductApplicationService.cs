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
        Task<List<ProductResponse>> GetProducts();

        Task<ProductResponse> GetProductById(int productId);

        Task DeleteProductById(int productId);

        Task<ProductResponse> CreateProduct(CreateProductRequest product);

        Task<ProductResponse> UpdateProduct(int productId, UpdateProductRequest product);
    }
}
