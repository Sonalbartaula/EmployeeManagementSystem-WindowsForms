using System;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Helpers;

namespace EmployeeManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form load event (optional)
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == username);

                    if (user == null)
                    {
                        MessageBox.Show("Invalid username or password.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
                    {
                        MessageBox.Show("Invalid username or password.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show($"Welcome back, {username}!",
                        "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DashboardForm dashboardForm = new DashboardForm(user);
                    dashboardForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
            this.Close();
        }
    }
}