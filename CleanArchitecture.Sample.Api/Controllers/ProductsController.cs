using CleanArchitecture.Sample.Application.DTOs.Requests;
using CleanArchitecture.Sample.Application.DTOs.Responses;
using CleanArchitecture.Sample.Application.Interfaces.ApplicationServices;
using CleanArchitecture.Sample.Application.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplicationService _aplicationService;
        public ProductsController(IProductApplicationService applicationService)
        {
            _aplicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<List<ProductResponse>> GetProducts()
        {
            return Ok(_aplicationService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = _aplicationService.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(CreateProductRequest request)
        {
            var product = _aplicationService.CreateProduct(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateProductRequest request)
        {
            try
            {
                var product = _aplicationService.UpdateProduct(id, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _aplicationService.DeleteProductById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
