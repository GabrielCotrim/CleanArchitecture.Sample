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

        public ProductResponse CreateProduct(CreateProductRequest product)
        {
            var createdProduct = _service.CreateProduct(_mapper.Map<Product>(product));
            return _mapper.Map<ProductResponse>(createdProduct);
        }

        public void DeleteProductById(int productId)
        {
            _service.DeleteProductById(productId);
        }

        public ProductResponse GetProductById(int productId)
        {
            var product = _service.GetProductById(productId);
            return _mapper.Map<ProductResponse>(product);
        }

        public List<ProductResponse> GetProducts()
        {
            return _service.GetProducts().Select(p => _mapper.Map<ProductResponse>(p)).ToList();
        }

        public ProductResponse UpdateProduct(int productId, UpdateProductRequest product)
        {
            var updatedProduct = _service.UpdateProduct(productId, _mapper.Map<Product>(product));
            return _mapper.Map<ProductResponse>(updatedProduct);
        }
    }
}
