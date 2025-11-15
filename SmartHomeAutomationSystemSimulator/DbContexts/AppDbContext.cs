using Microsoft.EntityFrameworkCore;
using SmartHomeAutomationSystemSimulator.Models;
using SmartHomeAutomationSystemSimulator.DataSeeders;

namespace SmartHomeAutomationSystemSimulator.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SmartDevice> SmartDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SmartDeviceSeeder.Seed(modelBuilder);
        }
    }
}
