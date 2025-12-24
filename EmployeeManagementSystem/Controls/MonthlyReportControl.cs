using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public class MonthlyReportControl : UserControl
    {
        private ComboBox cmbEmployeeName;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;
        private ComboBox cmbDay;
        private DataGridView dgvReport;
        private Button btnFetchData;
        private Button btnBack;
        private Button btnPrint;
        private Button btnCheckEmployee;
        private Button btnCheckYear;
        private Button btnCheckMonth;
        private int? selectedEmployeeId = null;

        public MonthlyReportControl()
        {
            SetupUI();
            LoadEmployees();
            LoadYears();
            LoadMonths();
            LoadDays();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1400, 750);

            // Title
            Label lblTitle = new Label
            {
                Text = "Monthly Report Data Sheet",
                Location = new Point(500, 80),
                Size = new Size(500, 45),  
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false  
            };
            this.Controls.Add(lblTitle);

            // Back Button
            btnBack = new Button
            {
                Text = "←",
                Location = new Point(30, 115),
                Size = new Size(50, 40),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.White
            };
            btnBack.FlatAppearance.BorderColor = Color.Black;
            btnBack.FlatAppearance.BorderSize = 1;
            this.Controls.Add(btnBack);

            // Fetch Data Button
            btnFetchData = new Button
            {
                Text = "Fetch Data",
                Location = new Point(1220, 115),
                Size = new Size(140, 40),
                BackColor = ColorTranslator.FromHtml("#2C5282"),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnFetchData.FlatAppearance.BorderSize = 0;
            btnFetchData.Click += BtnFetchData_Click;
            this.Controls.Add(btnFetchData);

            // Employee Name
            Label lblEmployee = new Label
            {
                Text = "Employee Name",
                Location = new Point(50, 208),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblEmployee);

            cmbEmployeeName = new ComboBox
            {
                Location = new Point(200, 205),
                Size = new Size(180, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbEmployeeName.SelectedIndexChanged += CmbEmployeeName_SelectedIndexChanged;
            this.Controls.Add(cmbEmployeeName);

            btnCheckEmployee = new Button
            {
                Text = "✓",
                Location = new Point(385, 205),
                Size = new Size(30, 27),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnCheckEmployee.FlatAppearance.BorderSize = 1;
            btnCheckEmployee.Click += BtnCheckEmployee_Click;
            this.Controls.Add(btnCheckEmployee);

            // Year
            Label lblYear = new Label
            {
                Text = "Year",
                Location = new Point(480, 208),
                Size = new Size(50, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblYear);

            cmbYear = new ComboBox
            {
                Location = new Point(530, 205),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbYear);

            btnCheckYear = new Button
            {
                Text = "✓",
                Location = new Point(615, 205),
                Size = new Size(30, 27),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnCheckYear.FlatAppearance.BorderSize = 1;
            this.Controls.Add(btnCheckYear);

            // Month
            Label lblMonth = new Label
            {
                Text = "Month",
                Location = new Point(690, 208),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblMonth);

            cmbMonth = new ComboBox
            {
                Location = new Point(775, 205),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbMonth);

            btnCheckMonth = new Button
            {
                Text = "✓",
                Location = new Point(910, 205),
                Size = new Size(30, 27),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnCheckMonth.FlatAppearance.BorderSize = 1;
            this.Controls.Add(btnCheckMonth);

            // Day
            Label lblDay = new Label
            {
                Text = "Day",
                Location = new Point(985, 208),
                Size = new Size(40, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblDay);

            cmbDay = new ComboBox
            {
                Location = new Point(1030, 205),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbDay);

            // Print Button
            btnPrint = new Button
            {
                Text = "🖨",
                Location = new Point(1310, 185),
                Size = new Size(45, 45),
                Font = new Font("Segoe UI", 16),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.White
            };
            btnPrint.FlatAppearance.BorderSize = 1;
            btnPrint.Click += BtnPrint_Click;
            this.Controls.Add(btnPrint);

            // DataGridView
            dgvReport = new DataGridView
            {
                Location = new Point(25, 270),
                Size = new Size(1340, 400),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = true,
                RowHeadersWidth = 30
            };

            // Add columns
            dgvReport.Columns.Add("UserId", "UserId");
            dgvReport.Columns.Add("Name", "Name");
            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("NepaliDate", "NepaliDate");
            dgvReport.Columns.Add("CheckIn", "CheckIn");
            dgvReport.Columns.Add("CheckOut", "CheckOut");

            // Style the header
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#4A5568");
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReport.ColumnHeadersHeight = 35;
            dgvReport.EnableHeadersVisualStyles = false;

            // Style rows
            dgvReport.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F7FAFC");
            dgvReport.RowsDefaultCellStyle.BackColor = Color.White;
            dgvReport.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4299E1");
            dgvReport.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvReport.RowTemplate.Height = 30;

            this.Controls.Add(dgvReport);

            // Footer
            Label lblFooter = new Label
            {
                Text = "Kutumba Tech Pvt. Ltd., Contact No: 9865212813",
                Location = new Point(450, 680),
                Size = new Size(500, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblFooter);
        }

        private void LoadEmployees()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var employees = db.Employees.ToList();
                    cmbEmployeeName.Items.Clear();
                    cmbEmployeeName.Items.Add(new ComboBoxItem { Text = "All Employees", Value = 0 });

                    foreach (var emp in employees)
                    {
                        cmbEmployeeName.Items.Add(new ComboBoxItem
                        {
                            Text = $"{emp.FirstName} {emp.LastName}",
                            Value = emp.Id
                        });
                    }

                    if (cmbEmployeeName.Items.Count > 0)
                        cmbEmployeeName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadYears()
        {
            cmbYear.Items.Clear();
            for (int year = 2020; year <= 2030; year++)
            {
                cmbYear.Items.Add(year);
            }
            cmbYear.SelectedItem = DateTime.Now.Year;
        }

        private void LoadMonths()
        {
            cmbMonth.Items.Clear();
            string[] months = { "All", "January", "February", "March", "April", "May",
                              "June", "July", "August", "September", "October",
                              "November", "December" };
            cmbMonth.Items.AddRange(months);
            cmbMonth.SelectedIndex = 0;
        }

        private void LoadDays()
        {
            cmbDay.Items.Clear();
            cmbDay.Items.Add("All");
            for (int day = 1; day <= 31; day++)
            {
                cmbDay.Items.Add(day);
            }
            cmbDay.SelectedIndex = 0;
        }

        private void CmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeeName.SelectedItem is ComboBoxItem item)
            {
                selectedEmployeeId = item.Value == 0 ? (int?)null : item.Value;
            }
        }

        private void BtnCheckEmployee_Click(object sender, EventArgs e)
        {
            BtnFetchData_Click(sender, e);
        }

        private void BtnFetchData_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var query = db.Attendances
                        .Include(a => a.Employee)
                        .AsQueryable();

                    // Filter by employee
                    if (selectedEmployeeId.HasValue)
                    {
                        query = query.Where(a => a.EmployeeId == selectedEmployeeId.Value);
                    }

                    // Filter by year
                    if (cmbYear.SelectedItem != null)
                    {
                        int year = Convert.ToInt32(cmbYear.SelectedItem);
                        query = query.Where(a => a.Date.Year == year);
                    }

                    // Filter by month
                    if (cmbMonth.SelectedIndex > 0)
                    {
                        int month = cmbMonth.SelectedIndex;
                        query = query.Where(a => a.Date.Month == month);
                    }

                    // Filter by day
                    if (cmbDay.SelectedIndex > 0 && cmbDay.SelectedItem.ToString() != "All")
                    {
                        int day = Convert.ToInt32(cmbDay.SelectedItem);
                        query = query.Where(a => a.Date.Day == day);
                    }

                    var attendances = query
                        .OrderByDescending(a => a.Date)
                        .ToList();

                    dgvReport.Rows.Clear();

                    foreach (var att in attendances)
                    {
                        dgvReport.Rows.Add(
                            att.EmployeeId,
                            $"{att.Employee.FirstName} {att.Employee.LastName}",
                            att.Date.ToString("MM/dd/yyyy"),
                            att.NepaliDate ?? "",
                            att.CheckIn.ToString(@"hh\:mm\:ss"),
                            att.CheckOut.ToString(@"hh\:mm\:ss") ?? ""
                        );
                    }

                    if (dgvReport.Rows.Count == 0)
                    {
                        MessageBox.Show("No attendance records found for the selected criteria.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Print functionality will open print dialog.\n\nNote: Implement PrintDocument for actual printing.",
                    "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Helper class for ComboBox items
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}