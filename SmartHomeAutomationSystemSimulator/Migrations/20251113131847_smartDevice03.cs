using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAutomationSystemSimulator.Migrations
{
    /// <inheritdoc />
    public partial class smartDevice03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SmartDevices",
                columns: new[] { "Id", "InstalledDate", "IsOn", "Location", "Manufacturer", "Name", "PowerConsumption", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Living Room", "Philips", "Smart Light", 15.0, "Lighting" },
                    { 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hallway", "Nest", "Smart Thermostat", 40.0, "HVAC" },
                    { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Front Door", "August", "Smart Door Lock", 10.0, "Security" },
                    { 4, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Garage", "Ring", "Smart Camera", 20.0, "Security" },
                    { 5, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bedroom", "Amazon", "Smart Speaker", 25.0, "Audio" },
                    { 6, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kitchen", "TP-Link", "Smart Plug", 5.0, "Power" },
                    { 7, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kitchen", "Samsung", "Smart Refrigerator", 200.0, "Appliance" },
                    { 8, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Laundry Room", "LG", "Smart Washer", 150.0, "Appliance" },
                    { 9, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Living Room", "Sony", "Smart TV", 120.0, "Entertainment" },
                    { 10, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bedroom", "Dyson", "Smart Air Purifier", 60.0, "Environment" },
                    { 11, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kitchen", "Breville", "Smart Coffee Maker", 1000.0, "Appliance" },
                    { 12, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Living Room", "Xiaomi", "Smart Fan", 50.0, "Cooling" },
                    { 13, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Living Room", "iRobot", "Smart Vacuum", 70.0, "Cleaning" },
                    { 14, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Front Door", "Ring", "Smart Doorbell", 10.0, "Security" },
                    { 15, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kitchen", "Ninja", "Smart Blender", 300.0, "Appliance" },
                    { 16, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kitchen", "Samsung", "Smart Oven", 2500.0, "Appliance" },
                    { 17, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bedroom", "Govee", "Smart Lights Strip", 20.0, "Lighting" },
                    { 18, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Living Room", "LG", "Smart Air Conditioner", 1500.0, "Cooling" },
                    { 19, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bedroom", "Levoit", "Smart Humidifier", 30.0, "Environment" },
                    { 20, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Garage", "Chamberlain", "Smart Garage Door", 15.0, "Security" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SmartDevices",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
