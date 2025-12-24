using System;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Helpers;

namespace EmployeeManagementSystem.Forms
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            try
            {

                string path = Path.Combine(
                    Application.StartupPath,
                    "Assets",
                    "FingerPrint.png"
                    );
                pictureBoxFingerprint.Image = Image.FromFile(path);
            }
            catch
            {

                pictureBoxFingerprint.BackColor = System.Drawing.Color.FromArgb(135, 206, 235);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email validation
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Check if username already exists
                    if (db.Users.Any(u => u.Username == username))
                    {
                        MessageBox.Show("Username already exists. Please choose another.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create new user
                    var user = new User
                    {
                        Username = username,
                        PasswordHash = PasswordHelper.HashPassword(password),
                        Role = "User",
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Account created successfully! Please login.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to login form
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing && !this.Visible)
            {
                e.Cancel = true;
            }
        }

       
    }
}