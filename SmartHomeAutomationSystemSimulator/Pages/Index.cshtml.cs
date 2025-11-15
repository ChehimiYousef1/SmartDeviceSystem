using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartHomeAutomationSystemSimulator.DbContexts;
using SmartHomeAutomationSystemSimulator.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomationSystemSimulator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // List of devices to show on page
        public IList<SmartDevice> SmartDevices { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                SmartDevices = await _context.SmartDevices.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading devices");
                SmartDevices = new List<SmartDevice>();
            }
        }

        // Toggle On/Off - Returns JSON for AJAX
        [BindProperty]
        public int Id { get; set; }

        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnPostToggleAsync(int id)
        {
            try
            {
                _logger.LogInformation("Toggling device with ID {Id}", id);

                var device = await _context.SmartDevices.FindAsync(id);
                if (device == null)
                {
                    return new JsonResult(new { success = false, message = "Device not found" })
                    { StatusCode = 404 };
                }

                device.Toggle();
                await _context.SaveChangesAsync();

                return new JsonResult(new
                {
                    success = true,
                    message = "Device state toggled successfully",
                    isOn = device.IsOn
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling device {Id}", id);
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while toggling device"
                })
                { StatusCode = 500 };
            }
        }


        // Details for AJAX
        public async Task<JsonResult> OnPostDetailsAsync(int id)
        {
            try
            {
                var device = await _context.SmartDevices.FindAsync(id);
                if (device == null)
                {
                    return new JsonResult(new { success = false, message = "Device not found" });
                }

                return new JsonResult(new
                {
                    success = true,
                    data = new
                    {
                        id = device.Id,
                        name = device.Name,
                        type = device.Type,
                        powerConsumption = device.PowerConsumption,
                        location = device.Location,
                        manufacturer = device.Manufacturer,
                        installedDate = device.InstalledDate.ToString("yyyy-MM-dd"),
                        status = device.IsOn ? "ON" : "OFF"
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching device details for device {Id}", id);
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while fetching device details"
                });
            }
        }

        // Edit handler for AJAX
        public async Task<JsonResult> OnPostEditAsync([FromBody] UpdateDeviceRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new JsonResult(new { success = false, message = "Invalid data" });
                }

                // Validate input
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new JsonResult(new { success = false, message = "Device name is required" });
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    return new JsonResult(new { success = false, message = "Device type is required" });
                }

                if (request.PowerConsumption <= 0)
                {
                    return new JsonResult(new { success = false, message = "Power consumption must be greater than 0" });
                }

                var device = await _context.SmartDevices.FindAsync(request.Id);
                if (device == null)
                {
                    return new JsonResult(new { success = false, message = "Device not found" });
                }

                // Update fields
                device.Name = request.Name.Trim();
                device.Type = request.Type.Trim();
                device.PowerConsumption = request.PowerConsumption;
                device.Location = request.Location?.Trim() ?? string.Empty;
                device.Manufacturer = request.Manufacturer?.Trim() ?? string.Empty;
                device.InstalledDate = request.InstalledDate;

                await _context.SaveChangesAsync();

                return new JsonResult(new { success = true, message = "Device updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating device");
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while updating device"
                });
            }
        }

        // Delete handler for AJAX
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var device = await _context.SmartDevices.FindAsync(id);
                if (device == null)
                {
                    return new JsonResult(new { success = false, message = "Device not found" });
                }

                _context.SmartDevices.Remove(device);
                await _context.SaveChangesAsync();

                return new JsonResult(new { success = true, message = "Device deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting device {Id}", id);
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while deleting device"
                });
            }
        }

        // Search handler - matches frontend form data submission
        [BindProperty]
        public string Query { get; set; } = string.Empty;

        public async Task<JsonResult> OnPostSearchAsync()
        {
            try
            {
                // If query is empty or whitespace, return all devices
                if (string.IsNullOrWhiteSpace(Query))
                {
                    var allDevices = await _context.SmartDevices
                        .Select(d => new
                        {
                            id = d.Id,
                            name = d.Name,
                            type = d.Type,
                            powerConsumption = d.PowerConsumption,
                            location = d.Location,
                            manufacturer = d.Manufacturer,
                            installedDate = d.InstalledDate.ToString("yyyy-MM-dd"),
                            isOn = d.IsOn
                        })
                        .ToListAsync();

                    return new JsonResult(new { success = true, data = allDevices });
                }

                // Perform search
                var q = Query.Trim().ToLower();
                var devices = await _context.SmartDevices
                    .Where(d => d.Name.ToLower().Contains(q) ||
                                d.Type.ToLower().Contains(q) ||
                                d.Location.ToLower().Contains(q))
                    .Select(d => new
                    {
                        id = d.Id,
                        name = d.Name,
                        type = d.Type,
                        powerConsumption = d.PowerConsumption,
                        location = d.Location,
                        manufacturer = d.Manufacturer,
                        installedDate = d.InstalledDate.ToString("yyyy-MM-dd"),
                        isOn = d.IsOn
                    })
                    .ToListAsync();

                return new JsonResult(new { success = true, data = devices });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching devices with query: {Query}", Query);
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while searching devices"
                });
            }
        }

       
        public async Task<JsonResult> OnPostAddAsync()
        {
            try
            {
                var form = Request.Form;
                var device = new SmartDevice
                {
                    Name = form["Name"],
                    Type = form["Type"],
                    PowerConsumption = int.Parse(form["PowerConsumption"]),
                    Location = form["Location"],
                    Manufacturer = form["Manufacturer"],
                    InstalledDate = DateTime.Parse(form["InstalledDate"]),
                };


        _context.SmartDevices.Add(device);
                await _context.SaveChangesAsync();

                return new JsonResult(new
                {
                    success = true,
                    message = "Device added successfully",
                    data = new
                    {
                        id = device.Id,
                        name = device.Name,
                        type = device.Type,
                        powerConsumption = device.PowerConsumption,
                        location = device.Location,
                        manufacturer = device.Manufacturer,
                        installedDate = device.InstalledDate.ToString("yyyy-MM-dd"),
                        isOn = device.IsOn
                    }
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "Error adding device",
                    error = ex.Message
                });
            }
        }


        // Helper class for the edit request
        public class UpdateDeviceRequest
        {
            [Required]
            public int Id { get; set; }

            [Required]
            [StringLength(100, MinimumLength = 1)]
            public string Name { get; set; } = string.Empty;

            [Required]
            [StringLength(50, MinimumLength = 1)]
            public string Type { get; set; } = string.Empty;

            [Range(1, 10000)]
            public int PowerConsumption { get; set; }

            [StringLength(100)]
            public string Location { get; set; } = string.Empty;

            [StringLength(100)]
            public string Manufacturer { get; set; } = string.Empty;

            [Required]
            public DateTime InstalledDate { get; set; }
        }
    }
}