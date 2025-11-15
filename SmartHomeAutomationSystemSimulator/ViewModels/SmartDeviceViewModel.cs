using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomationSystemSimulator.ViewModels
{
    public class SmartDeviceViewModel
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Criteria: Smart + Id
        [Display(Name = "Device Criteria")]
        public string Criteria => $"Smart{Id}";

        // Device Name
        [Required(ErrorMessage = "Device Name is required.")]
        [StringLength(100, ErrorMessage = "Device Name cannot exceed 100 characters.")]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        // Device Type
        [Required(ErrorMessage = "Device Type is required.")]
        [StringLength(50, ErrorMessage = "Device Type cannot exceed 50 characters.")]
        [Display(Name = "Device Type")]
        public string Type { get; set; }

        // State: On / Off
        [Required(ErrorMessage = "Device state is required.")]
        [Display(Name = "Device State")]
        public bool IsOn { get; set; }

        // Power Consumption in Watts
        [Required(ErrorMessage = "Power consumption is required.")]
        [Range(0.1, 10000, ErrorMessage = "Power consumption must be between 0.1W and 10000W.")]
        [Display(Name = "Power Consumption (W)")]
        public double PowerConsumption { get; set; }

        // Location
        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        // Manufacturer
        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        // Installed Date
        [Required(ErrorMessage = "Installed Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Installed Date")]
        public DateTime InstalledDate { get; set; } = DateTime.Now;
    }
}
