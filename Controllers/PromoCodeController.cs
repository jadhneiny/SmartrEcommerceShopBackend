using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly PromoCodeRepository _promoCodeRepository;

        public PromoCodeController(PromoCodeRepository promoCodeRepository)
        {
            _promoCodeRepository = promoCodeRepository;
        }

        [HttpGet("all/{tenantId}")]
        public async Task<IActionResult> GetAllPromoCodes(int tenantId)
        {
            var promoCodes = await _promoCodeRepository.GetAllAsync(tenantId);
            return Ok(promoCodes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromoCodeById(int id)
        {
            var promoCode = await _promoCodeRepository.GetByIdAsync(id);
            if (promoCode == null) return NotFound();
            return Ok(promoCode);
        }
    }
}
