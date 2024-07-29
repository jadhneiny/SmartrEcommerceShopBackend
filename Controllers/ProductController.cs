using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("tenant/{tenantId}")]
        public async Task<IActionResult> GetProducts(int tenantId)
        {
            var products = await _productRepository.GetAllAsync(tenantId);
            if (products == null || !products.Any())
            {
                return NotFound("No products found for the specified tenant.");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
