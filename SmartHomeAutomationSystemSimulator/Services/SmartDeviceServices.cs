using Microsoft.EntityFrameworkCore;
using SmartHomeAutomationSystemSimulator.DbContexts;
using SmartHomeAutomationSystemSimulator.Models;
using SmartHomeAutomationSystemSimulator.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartHomeAutomationSystemSimulator.Services
{
    public class SmartDeviceServices
    {
        private readonly AppDbContext _context;

        public SmartDeviceServices(AppDbContext context)
        {
            _context = context;
        }

        // Get all devices
        public List<SmartDeviceViewModel> GetAllDevices()
        {
            return _context.SmartDevices
                           .AsEnumerable() // ✅ Moves evaluation to memory
                           .Select(d => MapToViewModel(d))
                           .ToList();
        }


        // Get device by Id
        public SmartDeviceViewModel GetDeviceById(int id)
        {
            var device = _context.SmartDevices.Find(id);
            if (device == null) return null;
            return MapToViewModel(device);
        }

        // ✅ Add new device
        public SmartDeviceViewModel AddDevice(SmartDeviceViewModel model)
        {
            // ✅ Create SmartDevice entity (not ViewModel)
            var device = new SmartDevice(
                model.Name,
                model.Type,
                model.PowerConsumption,
                model.Location,
                model.Manufacturer
            )
            {
                InstalledDate = model.InstalledDate
            };

            // ✅ Set the device state using public methods
            if (model.IsOn)
                device.TurnOn();
            else
                device.TurnOff();

            // ✅ Save to database
            _context.SmartDevices.Add(device);
            _context.SaveChanges();

            // ✅ Return mapped ViewModel
            return MapToViewModel(device);
        }

        // Update existing device
        public bool UpdateDevice(int id, SmartDeviceViewModel model)
        {
            var device = _context.SmartDevices.Find(id);
            if (device == null) return false;

            device.Name = model.Name;
            device.Type = model.Type;
            device.PowerConsumption = model.PowerConsumption;
            device.Location = model.Location;
            device.Manufacturer = model.Manufacturer;
            device.InstalledDate = model.InstalledDate;

            if (model.IsOn)
                device.TurnOn();
            else
                device.TurnOff();

            _context.SaveChanges();
            return true;
        }


        // Delete device
        public bool DeleteDevice(int id)
        {
            var device = _context.SmartDevices.Find(id);
            if (device == null)
                return false;

            try
            {
                _context.SmartDevices.Remove(device);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting device: {ex.Message}");
                return false;
            }
        }



        // Search devices by any field
        public List<SmartDeviceViewModel> SearchDevices(string query)
        {
            query = query.ToLower();

            return _context.SmartDevices
                           .Where(d =>
                               d.Name.ToLower().Contains(query) ||
                               d.Type.ToLower().Contains(query) ||
                               d.Location.ToLower().Contains(query) ||
                               d.Manufacturer.ToLower().Contains(query)
                           )
                           .Select(d => MapToViewModel(d))
                           .ToList();
        }

        // Helper: Map SmartDevice → SmartDeviceViewModel
        private static SmartDeviceViewModel MapToViewModel(SmartDevice device)
        {
            return new SmartDeviceViewModel
            {
                Id = device.Id,
                Name = device.Name,
                Type = device.Type,
                IsOn = device.IsOn,
                PowerConsumption = device.PowerConsumption,
                Location = device.Location,
                Manufacturer = device.Manufacturer,
                InstalledDate = device.InstalledDate
            };
        }

    }
}
