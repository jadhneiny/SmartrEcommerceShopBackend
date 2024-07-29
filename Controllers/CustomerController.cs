using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("tenant/{tenantId}")]
        public async Task<IActionResult> GetCustomers(int tenantId)
        {
            var customers = await _customerRepository.GetAllAsync(tenantId);
            if (customers == null || !customers.Any())
            {
                return NotFound("No customers found for the specified tenant.");
            }
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
