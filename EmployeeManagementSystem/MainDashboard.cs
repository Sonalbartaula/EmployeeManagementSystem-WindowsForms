// MainDashboard.cs
using EmployeeManagementSystem.Controls;
using EmployeeManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeManagementSystem.Forms
{
    public partial class MainDashboard : Form
    {
        private Panel navigationPanel;
        private Panel contentPanel;
        private User currentUser;

        public MainDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            SetupUI();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            // Any additional initialization
        }

        private void SetupUI()
        {
            // Navigation Panel
            navigationPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = ColorTranslator.FromHtml("#3E4756")
            };

            // Create Navigation Buttons
            CreateNavigationButton("Dashboard", 0, ShowDashboard, "🏠");
            CreateNavigationButton("Connection", 1, ShowConnection, "🔌");
            CreateNavigationButton("Employees", 2, ShowEmployees, "👥");
            CreateNavigationButton("Monthly Report", 3, ShowMonthlyReport, "📊");
            CreateNavigationButton("User Management", 4, ShowUserManagement, "👤");
            CreateNavigationButton("Holiday", 5, ShowHoliday, "🏖");
            CreateNavigationButton("Leave", 6, ShowLeave, "📋");
            CreateNavigationButton("Attendance", 7, ShowAttendance, "✓");

            this.Controls.Add(navigationPanel);

            // Content Panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(contentPanel);

            // Show default dashboard
            ShowDashboard();
        }

        private void CreateNavigationButton(string text, int position, EventHandler clickHandler, string icon = "")
        {
            Button btn = new Button
            {
                Text = $"{icon}\n{text}",
                Width = 170,
                Height = 60,
                Left = 10 + (position * 172),
                Top = 10,
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorTranslator.FromHtml("#4A5568"),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Click += clickHandler;

            // Hover effect
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#2D3748");
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#4A5568");

            navigationPanel.Controls.Add(btn);
        }

        private void ShowDashboard(object sender = null, EventArgs e = null)
        {
            contentPanel.Controls.Clear();

            // Create a simple dashboard panel
            Panel dashPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            Label lblWelcome = new Label
            {
                Text = $"Welcome, {currentUser.Username}!",
                Location = new Point(50, 30),
                Size = new Size(600, 45),
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2D3748")
            };
            dashPanel.Controls.Add(lblWelcome);

            Label lblRole = new Label
            {
                Text = $"Role: {currentUser.Role}",
                Location = new Point(50, 85),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 14),
                ForeColor = ColorTranslator.FromHtml("#718096")
            };
            dashPanel.Controls.Add(lblRole);

            // Add divider line
            Panel divider = new Panel
            {
                Location = new Point(50, 130),
                Size = new Size(1000, 2),
                BackColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            dashPanel.Controls.Add(divider);

            // Add section title
            Label lblStats = new Label
            {
                Text = "Today's Overview",
                Location = new Point(50, 155),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2D3748")
            };
            dashPanel.Controls.Add(lblStats);

            // Add stats cards with proper spacing (Y position increased)
            int cardY = 200; // Start cards below the header section
            int cardSpacing = 230; // Space between cards

            CreateStatCard(dashPanel, "Total Employees", "125", 50, cardY, ColorTranslator.FromHtml("#48BB78"));
            CreateStatCard(dashPanel, "Present Today", "118", 50 + cardSpacing, cardY, ColorTranslator.FromHtml("#4299E1"));
            CreateStatCard(dashPanel, "On Leave", "5", 50 + cardSpacing * 2, cardY, ColorTranslator.FromHtml("#F6AD55"));
            CreateStatCard(dashPanel, "Absent", "2", 50 + cardSpacing * 3, cardY, ColorTranslator.FromHtml("#FC8181"));

            contentPanel.Controls.Add(dashPanel);
        }

        private void CreateStatCard(Panel parent, string title, string value, int x, int y, Color color)
        {
            // Card container with shadow effect
            Panel cardShadow = new Panel
            {
                Location = new Point(x + 3, y + 3),
                Size = new Size(210, 130),
                BackColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            parent.Controls.Add(cardShadow);

            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(210, 130),
                BackColor = color,
                BorderStyle = BorderStyle.None
            };

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(0, 20),
                Size = new Size(210, 60),
                Font = new Font("Segoe UI", 42, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
            card.Controls.Add(lblValue);

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(0, 85),
                Size = new Size(210, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
            card.Controls.Add(lblTitle);

            parent.Controls.Add(card);
            card.BringToFront(); // Ensure card is above shadow
        }

        private void ShowConnection(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            ConnectDeviceControl control = new ConnectDeviceControl();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void ShowEmployees(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            EmployeeManagementControl control = new EmployeeManagementControl();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void ShowMonthlyReport(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            MonthlyReportControl control = new MonthlyReportControl();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void ShowUserManagement(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            UserManagementControl control = new UserManagementControl(currentUser);
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void ShowHoliday(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            Label lblPlaceholder = new Label
            {
                Text = "Holiday Management - Coming Soon",
                Font = new Font("Segoe UI", 20),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = ColorTranslator.FromHtml("#718096")
            };
            contentPanel.Controls.Add(lblPlaceholder);
        }

        private void ShowLeave(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            Label lblPlaceholder = new Label
            {
                Text = "Leave Management - Coming Soon",
                Font = new Font("Segoe UI", 20),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = ColorTranslator.FromHtml("#718096")
            };
            contentPanel.Controls.Add(lblPlaceholder);
        }

        private void ShowAttendance(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            AttendanceControl control = new AttendanceControl();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }
    }
}