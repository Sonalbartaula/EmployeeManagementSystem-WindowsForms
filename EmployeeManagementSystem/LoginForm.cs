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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = txtRole.Text.Trim();

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


                    if (!user.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Access Denied! You are trying to login as '{role}' but your account role is '{user.Role}'.\n\nPlease enter the correct role.",
                            "Role Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show($"Welcome back, {username}!\nLogged in as: {user.Role}",
                        "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MainDashboard mainDashboard = new MainDashboard(user);
                        mainDashboard.FormClosed += (s, args) => {
                            this.Show();
                            txtPassword.Clear();
                        };
                        mainDashboard.Show();
                    }
                    else if (user.Role == "User")
                    {
                        AttendanceForm attendance = new AttendanceForm(user);
                        attendance.FormClosed += (s, args) => this.Close();
                        attendance.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unauthorized role.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.FormClosed += (s, args) => this.Show();
            signupForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

       
    }
}