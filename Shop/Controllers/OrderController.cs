using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Services;
using Shop.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)

        {
            this.orderService = orderService;
        }
 
        [HttpPut("updateOrderStatus"), Authorize(Roles = "Moderator")]
        public async Task<ActionResult> UpdateOrderStatus(NewOrderStatusDTO request)
        {
            await orderService.UpdateOrderStatus(request);
            return Ok();
        }
        [HttpPost("createOrder"), Authorize(Roles = "Client")]
        public async Task<ActionResult> CreateOrder(NewOrderDTO request)
        {
            await orderService.CreateOrder(request);
            return Ok();
        }
        [HttpGet("getOrders"), Authorize(Roles = "Client, Moderator")]
        public async Task<ActionResult> GetAllOrders()
        {
            var orders = await orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("getUserOrders"), Authorize(Roles = "Client")]
        public async Task<ActionResult> GetUserOrders(int id)
        {
            var orders = await orderService.GetUserOrders(id);
            return Ok(orders);
        }
    }
}
