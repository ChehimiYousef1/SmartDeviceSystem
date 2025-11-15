using Microsoft.EntityFrameworkCore;
using SmartHomeAutomationSystemSimulator.Models;
using System;

namespace SmartHomeAutomationSystemSimulator.DataSeeders
{
    public static class SmartDeviceSeeder
    {
        public static void Seed(ModelBuilder modelBuilder) => modelBuilder.Entity<SmartDevice>().HasData(
            new SmartDevice { Id = 1, Name = "Smart Light", Type = "Lighting", PowerConsumption = 15, Location = "Living Room", Manufacturer = "Philips", InstalledDate = DateTime.Parse("2024-01-10") },
            new SmartDevice { Id = 2, Name = "Smart Thermostat", Type = "HVAC", PowerConsumption = 40, Location = "Hallway", Manufacturer = "Nest", InstalledDate = DateTime.Parse("2024-02-15") },
            new SmartDevice { Id = 3, Name = "Smart Door Lock", Type = "Security", PowerConsumption = 10, Location = "Front Door", Manufacturer = "August", InstalledDate = DateTime.Parse("2024-03-01") },
            new SmartDevice { Id = 4, Name = "Smart Camera", Type = "Security", PowerConsumption = 20, Location = "Garage", Manufacturer = "Ring", InstalledDate = DateTime.Parse("2024-03-20") },
            new SmartDevice { Id = 5, Name = "Smart Speaker", Type = "Audio", PowerConsumption = 25, Location = "Bedroom", Manufacturer = "Amazon", InstalledDate = DateTime.Parse("2024-04-05") },
            new SmartDevice { Id = 6, Name = "Smart Plug", Type = "Power", PowerConsumption = 5, Location = "Kitchen", Manufacturer = "TP-Link", InstalledDate = DateTime.Parse("2024-05-10") },
            new SmartDevice { Id = 7, Name = "Smart Refrigerator", Type = "Appliance", PowerConsumption = 200, Location = "Kitchen", Manufacturer = "Samsung", InstalledDate = DateTime.Parse("2024-06-01") },
            new SmartDevice { Id = 8, Name = "Smart Washer", Type = "Appliance", PowerConsumption = 150, Location = "Laundry Room", Manufacturer = "LG", InstalledDate = DateTime.Parse("2024-07-12") },
            new SmartDevice { Id = 9, Name = "Smart TV", Type = "Entertainment", PowerConsumption = 120, Location = "Living Room", Manufacturer = "Sony", InstalledDate = DateTime.Parse("2024-08-20") },
            new SmartDevice { Id = 10, Name = "Smart Air Purifier", Type = "Environment", PowerConsumption = 60, Location = "Bedroom", Manufacturer = "Dyson", InstalledDate = DateTime.Parse("2024-09-05") },
            new SmartDevice { Id = 11, Name = "Smart Coffee Maker", Type = "Appliance", PowerConsumption = 1000, Location = "Kitchen", Manufacturer = "Breville", InstalledDate = DateTime.Parse("2024-10-01") },
            new SmartDevice { Id = 12, Name = "Smart Fan", Type = "Cooling", PowerConsumption = 50, Location = "Living Room", Manufacturer = "Xiaomi", InstalledDate = DateTime.Parse("2024-10-15") },
            new SmartDevice { Id = 13, Name = "Smart Vacuum", Type = "Cleaning", PowerConsumption = 70, Location = "Living Room", Manufacturer = "iRobot", InstalledDate = DateTime.Parse("2024-11-01") },
            new SmartDevice { Id = 14, Name = "Smart Doorbell", Type = "Security", PowerConsumption = 10, Location = "Front Door", Manufacturer = "Ring", InstalledDate = DateTime.Parse("2024-11-10") },
            new SmartDevice { Id = 15, Name = "Smart Blender", Type = "Appliance", PowerConsumption = 300, Location = "Kitchen", Manufacturer = "Ninja", InstalledDate = DateTime.Parse("2024-11-15") },
            new SmartDevice { Id = 16, Name = "Smart Oven", Type = "Appliance", PowerConsumption = 2500, Location = "Kitchen", Manufacturer = "Samsung", InstalledDate = DateTime.Parse("2024-12-01") },
            new SmartDevice { Id = 17, Name = "Smart Lights Strip", Type = "Lighting", PowerConsumption = 20, Location = "Bedroom", Manufacturer = "Govee", InstalledDate = DateTime.Parse("2024-12-10") },
            new SmartDevice { Id = 18, Name = "Smart Air Conditioner", Type = "Cooling", PowerConsumption = 1500, Location = "Living Room", Manufacturer = "LG", InstalledDate = DateTime.Parse("2024-12-20") },
            new SmartDevice { Id = 19, Name = "Smart Humidifier", Type = "Environment", PowerConsumption = 30, Location = "Bedroom", Manufacturer = "Levoit", InstalledDate = DateTime.Parse("2024-12-25") },
            new SmartDevice { Id = 20, Name = "Smart Garage Door", Type = "Security", PowerConsumption = 15, Location = "Garage", Manufacturer = "Chamberlain", InstalledDate = DateTime.Parse("2025-01-05") }
        );
    }
}
