using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository<TBL_ADMINS> _adminRepository;

        public AdminController(IUserRepository<TBL_ADMINS> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("{tenantId}")]
        public async Task<IActionResult> GetAdmins(int tenantId)
        {
            var admins = await _adminRepository.GetAllAsync(tenantId);
            return Ok(admins);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TBL_ADMINS admin)
        {
            var result = await _adminRepository.AddAsync(admin);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TBL_ADMINS admin)
        {
            var result = await _adminRepository.UpdateAsync(admin);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _adminRepository.DeleteAsync(id);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
