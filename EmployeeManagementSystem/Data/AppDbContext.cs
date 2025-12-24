using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using System.IO;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        // ONE database path for everything - development and production
        private static readonly string DbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "EmployeeManagementSystem",
            "app.db"
        );

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<DeviceSetting> DeviceSettings { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Ensure directory exists
            string directory = Path.GetDirectoryName(DbPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }

        // Helper method to get the database path
        public static string GetDatabasePath()
        {
            return DbPath;
        }
    }
}