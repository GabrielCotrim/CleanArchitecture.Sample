using AutoMapper;
using CleanArchitecture.Sample.Application.DTOs.Requests;
using CleanArchitecture.Sample.Application.DTOs.Responses;
using CleanArchitecture.Sample.Application.Interfaces.ApplicationServices;
using CleanArchitecture.Sample.Application.Interfaces.Services;
using CleanArchitecture.Sample.Domain.Entities;

namespace CleanArchitecture.Sample.Application.ApplicationServices
{
    public sealed class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductApplicationService(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ProductResponse> CreateProduct(CreateProductRequest product)
        {
            var createdProduct = await _service.CreateProduct(_mapper.Map<Product>(product));
            return _mapper.Map<ProductResponse>(createdProduct);
        }

        public async Task DeleteProductById(int productId)
        {
            await _service.DeleteProductById(productId);
        }

        public async Task<ProductResponse> GetProductById(int productId)
        {
            var product = await _service.GetProductById(productId);
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _service.GetProducts();
            return products.Select(p => _mapper.Map<ProductResponse>(p)).ToList();
        }

        public async Task<ProductResponse> UpdateProduct(int productId, UpdateProductRequest product)
        {
            var updatedProduct = await _service.UpdateProduct(productId, _mapper.Map<Product>(product));
            return _mapper.Map<ProductResponse>(updatedProduct);
        }
    }
}
