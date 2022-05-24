using GreenhouseWebAPI.Models;
using GreenhouseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenhouseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5000/order
    public class OrderController : ControllerBase
    {
        private readonly ICrudService<OrderItem, int> _orderService;
        public OrderController(ICrudService<OrderItem, int> orderService)
        {
            _orderService = orderService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<OrderItem>> GetAll() => _orderService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<OrderItem> Get(int id)
        {
            var order = _orderService.Get(id);
            if (order is null) return NotFound();
            else return order;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(OrderItem order)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _orderService.Add(order);
                return CreatedAtAction(nameof(Create), new { id = order.OrderId }, order);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderItem order)
        {
            var existingOrderItem = _orderService.Get(id);
            if (existingOrderItem is null || existingOrderItem.OrderId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _orderService.Update(existingOrderItem, order);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _orderService.Get(id);
            if (order is null) return NotFound();
            _orderService.Delete(id);
            return NoContent();
        }
    }
}

