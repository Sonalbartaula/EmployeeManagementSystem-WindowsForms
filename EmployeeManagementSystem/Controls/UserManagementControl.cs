using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controls
{
    public class UserManagementControl : UserControl
    {
        private DataGridView dgvUsers;
        private TextBox txtUserId;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnRefresh;
        private User currentUser;

        public UserManagementControl(User user)
        {
            currentUser = user;
            SetupUI();
            LoadUsers();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1400, 750);

            // Title
            Label lblTitle = new Label
            {
                Text = "User Management",
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
                Size = new Size(400, 500),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = ColorTranslator.FromHtml("#F7FAFC")
            };
            this.Controls.Add(leftPanel);

            int yPos = 30;
            int spacing = 60;

            // User ID
            AddLabel(leftPanel, "User ID:", 20, yPos);
            txtUserId = AddTextBox(leftPanel, 150, yPos, 220);
            txtUserId.ReadOnly = true;
            txtUserId.BackColor = Color.LightGray;
            yPos += spacing;

            // Username
            AddLabel(leftPanel, "Username:", 20, yPos);
            txtUsername = AddTextBox(leftPanel, 150, yPos, 220);
            yPos += spacing;

            // Password
            AddLabel(leftPanel, "Password:", 20, yPos);
            txtPassword = AddTextBox(leftPanel, 150, yPos, 220);
            txtPassword.UseSystemPasswordChar = true;
            yPos += spacing;

            // Role
            AddLabel(leftPanel, "Role:", 20, yPos);
            cmbRole = new ComboBox
            {
                Location = new Point(150, yPos),
                Size = new Size(220, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new string[] { "Admin", "User" });
            leftPanel.Controls.Add(cmbRole);
            yPos += spacing + 30;

            // Buttons
            btnAdd = CreateButton(leftPanel, "Add", 20, yPos, 85, 35, ColorTranslator.FromHtml("#48BB78"));
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = CreateButton(leftPanel, "Update", 115, yPos, 85, 35, ColorTranslator.FromHtml("#4299E1"));
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = CreateButton(leftPanel, "Delete", 210, yPos, 85, 35, ColorTranslator.FromHtml("#F56565"));
            btnDelete.Click += BtnDelete_Click;

            yPos += 45;
            btnClear = CreateButton(leftPanel, "Clear", 20, yPos, 85, 35, ColorTranslator.FromHtml("#A0AEC0"));
            btnClear.Click += BtnClear_Click;

            // Right Panel - DataGridView
            Panel rightPanel = new Panel
            {
                Location = new Point(440, 80),
                Size = new Size(940, 600),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(rightPanel);

            btnRefresh = CreateButton(rightPanel, "🔄 Refresh", 820, 10, 100, 35, ColorTranslator.FromHtml("#2C5282"));
            btnRefresh.Click += BtnRefresh_Click;

            dgvUsers = new DataGridView
            {
                Location = new Point(10, 60),
                Size = new Size(920, 530),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C5282");
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersHeight = 40;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EDF2F7");

            rightPanel.Controls.Add(dgvUsers);
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

        private TextBox AddTextBox(Control parent, int x, int y, int width)
        {
            TextBox txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 30),
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            parent.Controls.Add(txt);
            return txt;
        }

        private Button CreateButton(Control parent, string text, int x, int y, int width, int height, Color backColor)
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

        private void LoadUsers()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var users = db.Users.Select(u => new
                    {
                        u.Id,
                        u.Username,
                        u.Role,
                        u.CreatedAt
                    }).ToList();

                    dgvUsers.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                txtUserId.Text = row.Cells["Id"].Value?.ToString();
                txtUsername.Text = row.Cells["Username"].Value?.ToString();
                cmbRole.Text = row.Cells["Role"].Value?.ToString();
                txtPassword.Clear();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                using (var db = new AppDbContext())
                {
                    var newUser = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        PasswordHash = PasswordHelper.HashPassword(txtPassword.Text),
                        Role = cmbRole.Text,
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("User added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a user to update.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput()) return;

                using (var db = new AppDbContext())
                {
                    int userId = int.Parse(txtUserId.Text);
                    var user = db.Users.Find(userId);

                    if (user != null)
                    {
                        user.Username = txtUsername.Text.Trim();
                        if (!string.IsNullOrEmpty(txtPassword.Text))
                        {
                            user.PasswordHash = PasswordHelper.HashPassword(txtPassword.Text);
                        }
                        user.Role = cmbRole.Text;

                        db.SaveChanges();
                        MessageBox.Show("User updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a user to delete.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int userId = int.Parse(txtUserId.Text);
                if (userId == currentUser.Id)
                {
                    MessageBox.Show("You cannot delete your own account!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this user?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                        var user = db.Users.Find(userId);
                        if (user != null)
                        {
                            db.Users.Remove(user);
                            db.SaveChanges();
                            MessageBox.Show("User deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtUserId.Text) && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtUserId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            txtUsername.Focus();
        }
    }
}
