using GreenhouseWebAPI.Models;
using GreenhouseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenhouseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5000/greenhouse
    public class GreenhouseController : ControllerBase
    {
        private readonly ICrudService<GreenhouseItem, int> _greenhouseService;
        public GreenhouseController(ICrudService<GreenhouseItem, int> greenhouseService)
        {
            _greenhouseService = greenhouseService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<GreenhouseItem>> GetAll() => _greenhouseService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<GreenhouseItem> Get(int id)
        {
            var greenhouse = _greenhouseService.Get(id);
            if (greenhouse is null) return NotFound();
            else return greenhouse;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(GreenhouseItem greenhouse)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _greenhouseService.Add(greenhouse);
                return CreatedAtAction(nameof(Create), new { id = greenhouse.GreenhouseId }, greenhouse);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, GreenhouseItem greenhouse)
        {
            var existingGreenhouseItem = _greenhouseService.Get(id);
            if (existingGreenhouseItem is null || existingGreenhouseItem.GreenhouseId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _greenhouseService.Update(existingGreenhouseItem, greenhouse);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var greenhouse = _greenhouseService.Get(id);
            if (greenhouse is null) return NotFound();
            _greenhouseService.Delete(id);
            return NoContent();
        }
    }
}
