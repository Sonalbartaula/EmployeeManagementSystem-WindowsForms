namespace EmployeeManagementSystem.Forms
{
    partial class SignupForm
    {
        
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSignup = new Button();
            btnGoToLogin = new Button();
            SuspendLayout();
            
            // lblTitle
            
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(140, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(117, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sign Up";
            
            // lblUsername
            
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.Location = new Point(50, 80);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
             
            // txtUsername
            
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(50, 103);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 30);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += txtUsername_TextChanged;
            
            // lblPassword
            
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.Location = new Point(50, 150);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            
            // txtPassword
            
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(50, 173);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 30);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            
            // lblConfirmPassword
            
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F);
            lblConfirmPassword.Location = new Point(50, 220);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 20);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Confirm Password:";
            
            // txtConfirmPassword
            
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(50, 243);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(300, 30);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            
            // btnSignup
             
            btnSignup.BackColor = Color.FromArgb(0, 120, 215);
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSignup.ForeColor = Color.White;
            btnSignup.Location = new Point(50, 300);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(300, 40);
            btnSignup.TabIndex = 7;
            btnSignup.Text = "Sign Up";
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            
            // btnGoToLogin
            
            btnGoToLogin.FlatStyle = FlatStyle.Flat;
            btnGoToLogin.Font = new Font("Segoe UI", 9F);
            btnGoToLogin.Location = new Point(50, 350);
            btnGoToLogin.Name = "btnGoToLogin";
            btnGoToLogin.Size = new Size(300, 35);
            btnGoToLogin.TabIndex = 8;
            btnGoToLogin.Text = "Already have an account? Login";
            btnGoToLogin.UseVisualStyleBackColor = true;
            btnGoToLogin.Click += btnGoToLogin_Click;
             
            // SignupForm
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 420);
            Controls.Add(btnGoToLogin);
            Controls.Add(btnSignup);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SignupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management - Sign Up";
            Load += SignupForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Button btnGoToLogin;
    }
}