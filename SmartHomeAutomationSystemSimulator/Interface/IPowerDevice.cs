using SmartHomeAutomationSystemSimulator.Interfaces;

namespace SmartHomeAutomationSystemSimulator.Interfaces
{
    public interface IPowerDevice : IDevice
    {
        double PowerConsumption { get; set; }
    }
}
