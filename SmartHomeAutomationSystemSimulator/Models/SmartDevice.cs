using SmartHomeAutomationSystemSimulator.Interfaces;
using System;

namespace SmartHomeAutomationSystemSimulator.Models
{
    public class SmartDevice : IDevice, IPowerDevice
    {
        // EF Core will handle Id generation
        public int Id { get; set; }  // <-- must be public for HasData seeding

        public string Name { get; set; }
        public bool IsOn { get; private set; }
        public string Type { get; set; }
        public double PowerConsumption { get; set; }
        public string Location { get; set; }
        public string Manufacturer { get; set; }
        public DateTime InstalledDate { get; set; }

        // Constructor with ID (optional, mostly for seeding)
        public SmartDevice(int id, string name, string type, double powerConsumption, string location, string manufacturer)
        {
            Id = id;
            Name = name;
            Type = type;
            PowerConsumption = powerConsumption;
            Location = location;
            Manufacturer = manufacturer;
            InstalledDate = DateTime.Now;
            IsOn = false;
        }

        // Constructor without ID (for normal creation)
        public SmartDevice(string name, string type, double powerConsumption, string location, string manufacturer)
        {
            Name = name;
            Type = type;
            PowerConsumption = powerConsumption;
            Location = location;
            Manufacturer = manufacturer;
            InstalledDate = DateTime.Now;
            IsOn = false;
        }

        // Parameterless constructor required by EF Core
        public SmartDevice() { }

        // Methods to control state
        public void TurnOn() => IsOn = true;
        public void TurnOff() => IsOn = false;
        public void Toggle() => IsOn = !IsOn;

        // Optional: show device status
        public void ShowStatus()
        {
            Console.WriteLine($"Device: {Name}, Type: {Type}, State: {(IsOn ? "ON" : "OFF")}, Power: {PowerConsumption}W");
        }
    }
}
