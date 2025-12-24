using System;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private User currentUser;

        public DashboardForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUser.Username}!";
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var employees = db.Employees.ToList();
                    dgvEmployees.DataSource = employees;

                    // Hide unnecessary columns
                    if (dgvEmployees.Columns["Id"] != null)
                        dgvEmployees.Columns["Id"].Visible = false;

                    if (dgvEmployees.Columns["CreatedAt"] != null)
                        dgvEmployees.Columns["CreatedAt"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to edit.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;

            using (var db = new AppDbContext())
            {
                var employee = db.Employees.Find(employeeId);
                if (employee != null)
                {
                    EmployeeForm employeeForm = new EmployeeForm(employee);
                    if (employeeForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployees();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this employee?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int employeeId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;

                    using (var db = new AppDbContext())
                    {
                        var employee = db.Employees.Find(employeeId);
                        if (employee != null)
                        {
                            db.Employees.Remove(employee);
                            db.SaveChanges();
                            MessageBox.Show("Employee deleted successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close dashboard and let the login form handle showing itself again
                this.Close();
            }
        }
    }
}