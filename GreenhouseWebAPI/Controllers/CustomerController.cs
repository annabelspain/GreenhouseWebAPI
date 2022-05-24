using GreenhouseWebAPI.Models;
using GreenhouseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenhouseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/customer
    public class CustomerController : ControllerBase
    {
        private readonly ICrudService<Customer, int> _customerService;
        public CustomerController(ICrudService<Customer, int> customerService)
        {
            _customerService = customerService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Customer>> GetAll() => _customerService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customerService.Get(id);
            if (customer is null) return NotFound();
            else return customer;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _customerService.Add(customer);
                return CreatedAtAction(nameof(Create), new { id = customer.Id }, customer);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            var existingCustomerItem = _customerService.Get(id);
            if (existingCustomerItem is null || existingCustomerItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _customerService.Update(existingCustomerItem, customer);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.Get(id);
            if (customer is null) return NotFound();
            _customerService.Delete(id);
            return NoContent();
        }
    }
}
