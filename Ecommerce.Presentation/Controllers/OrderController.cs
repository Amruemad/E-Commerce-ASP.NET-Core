using Ecommerce.DTOs.Order;
using Ecommerce.DTOs.Product;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var allOrders = await orderService.GetAllOrders();

            if (allOrders != null)
            {
                return Ok(allOrders);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var order = await orderService.GetOneOrder(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("customerId/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetOrderByCustomerId([FromRoute] int id)
        {
            var orders = await orderService.GetOrdersOfCustomer(id);

            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateOrderDTO newOrder)
        {
            await orderService.CreateOrder(newOrder);
            return Ok("Created");
        }

        [HttpPut("update/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] CreateOrUpdateOrderDTO editOrder)
        {
            var oldOrderList = await orderService.GetOneOrder(id);
            var oldOrder = oldOrderList.FirstOrDefault();

            if(oldOrder == null)
            {
                return NotFound();
            }

            await orderService.UpdateOrder(oldOrder, editOrder);
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool deleteResult = await orderService.DeleteOrder(id);
            if (deleteResult)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
