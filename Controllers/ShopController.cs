using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopRepository _shopRepository;

        public ShopController(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet("all/{tenantId}")]
        public async Task<IActionResult> GetAllShops(int tenantId)
        {
            var shops = await _shopRepository.GetAllAsync(tenantId);
            return Ok(shops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopById(int id)
        {
            var shop = await _shopRepository.GetByIdAsync(id);
            if (shop == null) return NotFound();
            return Ok(shop);
        }
    }
}
