using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomationSystemSimulator.Services;
using SmartHomeAutomationSystemSimulator.ViewModels;
using System.Collections.Generic;

namespace SmartHomeAutomationSystemSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmartDeviceController : ControllerBase
    {
        private readonly SmartDeviceServices _deviceService;

        public SmartDeviceController(SmartDeviceServices deviceService)
        {
            _deviceService = deviceService;
        }

        // GET: api/SmartDevice
        [HttpGet]
        public IActionResult GetAllDevices()
        {
            var devices = _deviceService.GetAllDevices();

            if (devices == null || !devices.Any())
                return BadRequest("No devices found in the database.");

            return Ok(devices);
        }


        // GET: api/SmartDevice/5
        [HttpGet("{id}")]
        public ActionResult<SmartDeviceViewModel> GetById(int id)
        {
            var device = _deviceService.GetDeviceById(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        // POST: api/SmartDevice
        [HttpPost]
        public ActionResult<SmartDeviceViewModel> Create([FromBody] SmartDeviceViewModel model)
        {
            var created = _deviceService.AddDevice(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/SmartDevice/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SmartDeviceViewModel model)
        {
            var existingDevice = _deviceService.GetDeviceById(id);
            if (existingDevice == null)
                return NotFound(new { message = $"Device with ID {id} not found." });

            var updated = _deviceService.UpdateDevice(id, model);
            if (!updated)
                return BadRequest(new { message = "Failed to update the device." });

            var updatedDevice = _deviceService.GetDeviceById(id);
            return Ok(new
            {
                message = $"Device with ID {id} has been updated successfully.",
                updatedDevice
            });
        }


        [HttpPost("edit")]
        public IActionResult GetDeviceForEdit([FromBody] int id)
        {
            var existingDevice = _deviceService.GetDeviceById(id);
            if (existingDevice == null)
                return NotFound(new { message = $"Device with ID {id} not found." });

            return Ok(new
            {
                message = $"Device with ID {id} retrieved successfully.",
                device = existingDevice
            });
        }



        // DELETE: api/SmartDevice/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _deviceService.DeleteDevice(id);

            if (!deleted)
                return NotFound(new { message = $"Device with ID {id} was not found." });

            return Ok(new { message = $"Device with ID {id} has been deleted successfully." });
        }


        // GET: api/SmartDevice/search?query=...
        [HttpGet("search")]
        public ActionResult<List<SmartDeviceViewModel>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Search query cannot be empty.");

            var results = _deviceService.SearchDevices(query);

            if (results.Count == 0)
                return NotFound("No devices matched the search query.");

            return Ok(results);
        }
    }
}
