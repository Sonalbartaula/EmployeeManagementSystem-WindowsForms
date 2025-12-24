using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Forms
{
    public class EmployeeManagementControl : UserControl
    {
        private DataGridView dgvEmployees;
        private TextBox txtEmployeeId;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private ComboBox cmbDepartment;
        private TextBox txtPosition;
        private DateTimePicker dtpHireDate;
        private TextBox txtSalary;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnRefresh;
        private TextBox txtSearch;

        public EmployeeManagementControl()
        {
            SetupUI();
            LoadEmployees();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1400, 750);

            // Title
            Label lblTitle = new Label
            {
                Text = "Employee Management",
                Location = new Point(550, 20),
                Size = new Size(400, 40),
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            // Left Panel - Form
            Panel leftPanel = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(420, 620),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = ColorTranslator.FromHtml("#F7FAFC")
            };
            this.Controls.Add(leftPanel);

            // Form Fields
            int yPos = 20;
            int labelX = 20;
            int textBoxX = 150;
            int fieldHeight = 30;
            int spacing = 50;

            // Employee ID (Read-only)
            AddLabel(leftPanel, "Employee ID:", labelX, yPos);
            txtEmployeeId = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.BackColor = Color.LightGray;
            yPos += spacing;

            // First Name
            AddLabel(leftPanel, "First Name:", labelX, yPos);
            txtFirstName = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing;

            // Last Name
            AddLabel(leftPanel, "Last Name:", labelX, yPos);
            txtLastName = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing;

            // Email
            AddLabel(leftPanel, "Email:", labelX, yPos);
            txtEmail = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing;

            // Phone
            AddLabel(leftPanel, "Phone:", labelX, yPos);
            txtPhone = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing;

            // Department
            AddLabel(leftPanel, "Department:", labelX, yPos);
            cmbDepartment = new ComboBox
            {
                Location = new Point(textBoxX, yPos),
                Size = new Size(240, fieldHeight),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDepartment.Items.AddRange(new string[] {
                "IT", "HR", "Finance", "Marketing", "Operations", "Sales"
            });
            leftPanel.Controls.Add(cmbDepartment);
            yPos += spacing;

            // Position
            AddLabel(leftPanel, "Position:", labelX, yPos);
            txtPosition = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing;

            // Hire Date
            AddLabel(leftPanel, "Hire Date:", labelX, yPos);
            dtpHireDate = new DateTimePicker
            {
                Location = new Point(textBoxX, yPos),
                Size = new Size(240, fieldHeight),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short
            };
            leftPanel.Controls.Add(dtpHireDate);
            yPos += spacing;

            // Salary
            AddLabel(leftPanel, "Salary:", labelX, yPos);
            txtSalary = AddTextBox(leftPanel, textBoxX, yPos, 240, fieldHeight);
            yPos += spacing + 20;

            // Buttons
            int btnWidth = 90;
            int btnHeight = 38;
            int btnSpacing = 100;
            int btnY = yPos;

            btnAdd = CreateButton(leftPanel, "Add", 20, btnY, btnWidth, btnHeight,
                ColorTranslator.FromHtml("#48BB78"));
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = CreateButton(leftPanel, "Update", 20 + btnSpacing, btnY, btnWidth, btnHeight,
                ColorTranslator.FromHtml("#4299E1"));
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = CreateButton(leftPanel, "Delete", 20 + btnSpacing * 2, btnY, btnWidth, btnHeight,
                ColorTranslator.FromHtml("#F56565"));
            btnDelete.Click += BtnDelete_Click;

            btnClear = CreateButton(leftPanel, "Clear", 20 + btnSpacing * 3, btnY, btnWidth, btnHeight,
                ColorTranslator.FromHtml("#A0AEC0"));
            btnClear.Click += BtnClear_Click;

            // Right Panel - DataGridView
            Panel rightPanel = new Panel
            {
                Location = new Point(460, 80),
                Size = new Size(920, 620),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            this.Controls.Add(rightPanel);

            // Search Bar
            Label lblSearch = new Label
            {
                Text = "Search:",
                Location = new Point(10, 15),
                Size = new Size(70, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            rightPanel.Controls.Add(lblSearch);

            txtSearch = new TextBox
            {
                Location = new Point(80, 12),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            rightPanel.Controls.Add(txtSearch);

            btnRefresh = CreateButton(rightPanel, "🔄 Refresh", 800, 10, 100, 35,
                ColorTranslator.FromHtml("#2C5282"));
            btnRefresh.Click += BtnRefresh_Click;

            // DataGridView
            dgvEmployees = new DataGridView
            {
                Location = new Point(10, 60),
                Size = new Size(900, 550),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false
            };

            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;

            // Style the header
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C5282");
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.EnableHeadersVisualStyles = false;

            // Style rows
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EDF2F7");
            dgvEmployees.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4299E1");
            dgvEmployees.RowTemplate.Height = 35;

            rightPanel.Controls.Add(dgvEmployees);
        }

        private Label AddLabel(Control parent, string text, int x, int y)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            parent.Controls.Add(lbl);
            return lbl;
        }

        private TextBox AddTextBox(Control parent, int x, int y, int width, int height)
        {
            TextBox txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            parent.Controls.Add(txt);
            return txt;
        }

        private Button CreateButton(Control parent, string text, int x, int y,
            int width, int height, Color backColor)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = backColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            parent.Controls.Add(btn);
            return btn;
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
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                txtEmployeeId.Text = row.Cells["Id"].Value?.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
                txtLastName.Text = row.Cells["LastName"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                cmbDepartment.Text = row.Cells["Department"].Value?.ToString();
                txtPosition.Text = row.Cells["Position"].Value?.ToString();

                if (row.Cells["HireDate"].Value != null && row.Cells["HireDate"].Value != DBNull.Value)
                    dtpHireDate.Value = Convert.ToDateTime(row.Cells["HireDate"].Value);

                txtSalary.Text = row.Cells["Salary"].Value?.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                using (var db = new AppDbContext())
                {
                    var newEmployee = new Employee
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Department = cmbDepartment.Text,
                        Position = txtPosition.Text.Trim(),
                        HireDate = dtpHireDate.Value,
                        Salary = decimal.Parse(txtSalary.Text.Trim()),
                        CreatedAt = DateTime.Now
                    };

                    db.Employees.Add(newEmployee);
                    db.SaveChanges();

                    MessageBox.Show("Employee added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmployeeId.Text))
                {
                    MessageBox.Show("Please select an employee to update.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput()) return;

                using (var db = new AppDbContext())
                {
                    int employeeId = int.Parse(txtEmployeeId.Text);
                    var emp = db.Employees.Find(employeeId);

                    if (emp != null)
                    {
                        emp.FirstName = txtFirstName.Text.Trim();
                        emp.LastName = txtLastName.Text.Trim();
                        emp.Email = txtEmail.Text.Trim();
                        emp.Phone = txtPhone.Text.Trim();
                        emp.Department = cmbDepartment.Text;
                        emp.Position = txtPosition.Text.Trim();
                        emp.HireDate = dtpHireDate.Value;
                        emp.Salary = decimal.Parse(txtSalary.Text.Trim());

                        db.SaveChanges();
                        MessageBox.Show("Employee updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmployeeId.Text))
                {
                    MessageBox.Show("Please select an employee to delete.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this employee?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                        int employeeId = int.Parse(txtEmployeeId.Text);
                        var employee = db.Employees.Find(employeeId);

                        if (employee != null)
                        {
                            db.Employees.Remove(employee);
                            db.SaveChanges();
                            MessageBox.Show("Employee deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees();
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
            MessageBox.Show("Employee list refreshed!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    string searchText = txtSearch.Text.Trim().ToLower();

                    var employees = db.Employees
                        .Where(emp =>
                            emp.FirstName.ToLower().Contains(searchText) ||
                            emp.LastName.ToLower().Contains(searchText) ||
                            emp.Department.ToLower().Contains(searchText) ||
                            emp.Position.ToLower().Contains(searchText) ||
                            emp.Email.ToLower().Contains(searchText))
                        .ToList();

                    dgvEmployees.DataSource = employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please enter position.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtSalary.Text))
            {
                if (!decimal.TryParse(txtSalary.Text, out _))
                {
                    MessageBox.Show("Please enter a valid salary amount.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalary.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ClearFields()
        {
            txtEmployeeId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbDepartment.SelectedIndex = -1;
            txtPosition.Clear();
            dtpHireDate.Value = DateTime.Now;
            txtSalary.Clear();
            txtFirstName.Focus();
        }
    }
}