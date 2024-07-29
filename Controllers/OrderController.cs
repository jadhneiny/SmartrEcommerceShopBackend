using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<TBL_ORDERS> _orderRepository;

        public OrderController(IRepository<TBL_ORDERS> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{tenantId}")]
        public async Task<IActionResult> GetOrders(int tenantId)
        {
            var orders = await _orderRepository.GetAllAsync(tenantId);
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the specified tenant.");
            }
            return Ok(orders);
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] TBL_ORDERS order)
        {
            var result = await _orderRepository.AddAsync(order);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] TBL_ORDERS order)
        {
            var result = await _orderRepository.UpdateAsync(order);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("order/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteAsync(id);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
