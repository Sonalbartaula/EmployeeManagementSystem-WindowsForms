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
            // Form load event (optional)
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
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
                    if (db.Users.Any(u => u.Username == username))
                    {
                        MessageBox.Show("Username already exists. Please choose another.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var user = new User
                    {
                        Username = username,
                        PasswordHash = PasswordHelper.HashPassword(password),
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Account created successfully! Please login.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}