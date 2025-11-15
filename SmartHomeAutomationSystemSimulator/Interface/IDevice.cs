using System;

namespace SmartHomeAutomationSystemSimulator.Interfaces
{
    public interface IDevice
    {
        int Id { get; }
        string Name { get; set; }
        bool IsOn { get; }
        string Type { get; set; }

        void TurnOn();
        void TurnOff();
        void Toggle();
        void ShowStatus();
    }
}
