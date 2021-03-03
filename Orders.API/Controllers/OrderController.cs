using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Models;
using Orders.API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        // GET api/<controller>/5
        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            try
            {
                var order = await _orderService.GetOrderById(orderId);
                return Ok(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderModel order)
        {
            try
            {
                await _orderService.AddNewOrder(order);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}
