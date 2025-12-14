using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Forms;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize database
            try
            {
                using (var db = new AppDbContext())
                {
                    // Create database and tables if they don't exist
                    db.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Start with LoginForm instead of Form1
            Application.Run(new LoginForm());
        }
    }
}