using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controls
{
    public class ConnectDeviceControl : UserControl
    {
        private TextBox txtIP;
        private TextBox txtPort;
        private TextBox txtPassword;
        private Button btnConnect;
        private Label lblStatus;
        private Label lblDeviceStatus;

        public ConnectDeviceControl()
        {
            SetupUI();
            LoadSavedSettings();
        }

        private void SetupUI()
        {

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.BackColor = Color.White;


            // Title
            Label lblTitle = new Label
            {
                Text = "Device Connection",
                Location = new Point(500, 80),
                Size = new Size(400, 45),  
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false  
            };
            this.Controls.Add(lblTitle);
            // IP Address
            Label lblIP = new Label
            {
                Text = "IP Address :",
                Location = new Point(200, 210),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblIP);

            txtIP = new TextBox
            {
                Location = new Point(360, 210),
                Size = new Size(165, 30),
                Font = new Font("Segoe UI", 11),
                Text = "192.168.100.201",
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtIP);

            // Port Number
            Label lblPort = new Label
            {
                Text = "Port Number :",
                Location = new Point(600, 210),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblPort);

            txtPort = new TextBox
            {
                Location = new Point(760, 210),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 11),
                Text = "4370",
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtPort);

            // Password
            Label lblPassword = new Label
            {
                Text = "Password :",
                Location = new Point(920, 210),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblPassword);

            txtPassword = new TextBox
            {
                Location = new Point(1050, 210),
                Size = new Size(70, 30),
                Font = new Font("Segoe UI", 11),
                Text = "0",
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtPassword);

            // Connect Button
            btnConnect = new Button
            {
                Text = "Connect",
                Location = new Point(625, 310),
                Size = new Size(150, 50),
                BackColor = ColorTranslator.FromHtml("#2C5282"),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.Click += BtnConnect_Click;
            this.Controls.Add(btnConnect);

            // Status Labels
            lblStatus = new Label
            {
                Location = new Point(200, 420),
                Size = new Size(1000, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Gray,
                Text = "Click 'Connect' to establish connection with the device."
            };
            this.Controls.Add(lblStatus);

            lblDeviceStatus = new Label
            {
                Location = new Point(200, 460),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblDeviceStatus);
        }

        private void LoadSavedSettings()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var setting = db.DeviceSettings.FirstOrDefault();
                    if (setting != null)
                    {
                        txtIP.Text = setting.IPAddress;
                        txtPort.Text = setting.PortNumber.ToString();
                        txtPassword.Text = setting.Password;

                        if (setting.IsConnected)
                        {
                            lblStatus.Text = $"Last connected: {setting.LastConnected}";
                            lblStatus.ForeColor = Color.Green;
                        }
                    }
                }
            }
            catch { }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtIP.Text) ||
                    string.IsNullOrWhiteSpace(txtPort.Text))
                {
                    MessageBox.Show("Please enter IP address and port number.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPort.Text, out int port))
                {
                    MessageBox.Show("Please enter a valid port number.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save settings to database
                using (var db = new AppDbContext())
                {
                    var setting = db.DeviceSettings.FirstOrDefault();
                    if (setting == null)
                    {
                        setting = new DeviceSetting();
                        db.DeviceSettings.Add(setting);
                    }

                    setting.IPAddress = txtIP.Text.Trim();
                    setting.PortNumber = port;
                    setting.Password = txtPassword.Text.Trim();
                    setting.IsConnected = true;
                    setting.LastConnected = DateTime.Now;
                    setting.DeviceName = "Biometric Device";

                    db.SaveChanges();
                }

                // Update UI
                lblStatus.Text = $"Connected to device at address {txtIP.Text} with port number {txtPort.Text}";
                lblStatus.ForeColor = Color.Green;

                lblDeviceStatus.Text = "Device is Enabled";
                lblDeviceStatus.ForeColor = Color.Green;

                MessageBox.Show("Device connected successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Connection failed!";
                lblStatus.ForeColor = Color.Red;
                lblDeviceStatus.Text = "Device is Disabled";
                lblDeviceStatus.ForeColor = Color.Red;

                MessageBox.Show($"Error connecting to device: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
