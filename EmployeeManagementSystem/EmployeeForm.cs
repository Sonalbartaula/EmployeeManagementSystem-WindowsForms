using System;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Forms
{
    public partial class EmployeeForm : Form
    {
        private Employee employee;
        private bool isEditMode;

        public EmployeeForm(Employee emp = null)
        {
            employee = emp;
            isEditMode = emp != null;
            InitializeComponent();
           
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "Edit Employee";
                LoadEmployeeData();
            }
            else
            {
                this.Text = "Add Employee";
            }
        }

        private void LoadEmployeeData()
        {
            if (employee != null)
            {
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtEmail.Text = employee.Email;
                txtPhone.Text = employee.Phone;
                txtPosition.Text = employee.Position;
                txtDepartment.Text = employee.Department;
                txtSalary.Text = employee.Salary.ToString();
                dtpHireDate.Value = employee.HireDate;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var db = new AppDbContext())
                {
                    if (isEditMode)
                    {
                        var emp = db.Employees.Find(employee.Id);
                        if (emp != null)
                        {
                            emp.FirstName = txtFirstName.Text.Trim();
                            emp.LastName = txtLastName.Text.Trim();
                            emp.Email = txtEmail.Text.Trim();
                            emp.Phone = txtPhone.Text.Trim();
                            emp.Position = txtPosition.Text.Trim();
                            emp.Department = txtDepartment.Text.Trim();
                            emp.Salary = decimal.Parse(txtSalary.Text);
                            emp.HireDate = dtpHireDate.Value;

                            db.SaveChanges();
                            MessageBox.Show("Employee updated successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        var newEmployee = new Employee
                        {
                            FirstName = txtFirstName.Text.Trim(),
                            LastName = txtLastName.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            Position = txtPosition.Text.Trim(),
                            Department = txtDepartment.Text.Trim(),
                            Salary = decimal.Parse(txtSalary.Text),
                            HireDate = dtpHireDate.Value,
                            CreatedAt = DateTime.Now
                        };

                        db.Employees.Add(newEmployee);
                        db.SaveChanges();
                        MessageBox.Show("Employee added successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please enter position.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("Please enter department.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartment.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Please enter a valid salary.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalary.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}