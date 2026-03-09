using CRUD.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            return Ok(products);
        }
    }
}
