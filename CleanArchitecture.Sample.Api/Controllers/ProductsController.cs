using CleanArchitecture.Sample.Application.DTOs.Requests;
using CleanArchitecture.Sample.Application.DTOs.Responses;
using CleanArchitecture.Sample.Application.Interfaces.ApplicationServices;
using CleanArchitecture.Sample.Application.Utils.Exceptions;
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
        public async Task<ActionResult<List<ProductResponse>>> GetProducts()
        {
            return Ok(await _aplicationService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById([FromQuery] int id)
        {
            try
            {
                var product = await _aplicationService.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductRequest request)
        {
            var product = await _aplicationService.CreateProduct(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                var product = await _aplicationService.UpdateProduct(id, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _aplicationService.DeleteProductById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
