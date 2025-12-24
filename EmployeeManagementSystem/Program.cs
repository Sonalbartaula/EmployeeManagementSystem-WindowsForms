using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Forms;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Helpers;  
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    string dbPath = AppDbContext.GetDatabasePath();
                    db.Database.EnsureCreated();

                    // Create default admin user if no users exist
                    if (!db.Users.Any())
                    {
                        db.Users.Add(new User
                        {
                            Username = "admin",
                            PasswordHash = PasswordHelper.HashPassword("admin123"),  // ← Changed this
                            Role = "Admin",
                            CreatedAt = DateTime.Now
                        });
                        db.SaveChanges();

                        MessageBox.Show(
                            $"Database created at:\n{dbPath}\n\n" +
                            "Default admin user created:\n" +
                            "Username: admin\n" +
                            "Password: admin123\n" +
                            "Role: Admin",
                            "Database Initialized",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Database initialization error:\n{ex.Message}\n\n" +
                    $"Inner Exception: {ex.InnerException?.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}