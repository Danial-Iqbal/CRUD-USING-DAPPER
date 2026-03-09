using CRUD.WebApi.Models;
using CRUD.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUD.WebApi.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Product Operations")]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return NotFound(new { Message = $"Product with Id {id} not found." });

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product is null)
                return BadRequest(new { Message = $"Product Date is required" });

            var createdId = await _productRepository.CreateAsync(product);

            var result = await _productRepository.GetByIdAsync(createdId);

            return CreatedAtAction(nameof(Create), new { id = createdId }, result);
        }
    }
}
