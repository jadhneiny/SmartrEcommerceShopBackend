using Microsoft.AspNetCore.Mvc;
using ShopManagementBackend.Models;
using ShopManagementBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailController(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // Get all order details for a specific tenant
        [HttpGet("tenant/{tenantId}")]
        public async Task<IActionResult> GetOrderDetails(int tenantId)
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync(tenantId);
            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound("No order details found for the specified tenant.");
            }
            return Ok(orderDetails);
        }

        // Get a specific order detail by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }
    }
}
