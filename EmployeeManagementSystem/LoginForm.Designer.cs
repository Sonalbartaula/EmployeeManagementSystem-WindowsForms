namespace EmployeeManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

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
            panelLeft = new Panel();
            pictureBoxFingerprint = new PictureBox();
            panelRight = new Panel();
            lblCopyright = new Label();
            linkLabelSignup = new LinkLabel();
            lblClickHere = new Label();
            btnLogin = new Button();
            txtRole = new TextBox();
            lblRole = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblLoginPage = new Label();
            lblTitle = new Label();
            pictureBoxIcon = new PictureBox();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFingerprint).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.LightBlue;
            panelLeft.Controls.Add(pictureBoxFingerprint);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(374, 580);
            panelLeft.TabIndex = 0;
            // 
            // pictureBoxFingerprint
            // 
            pictureBoxFingerprint.Dock = DockStyle.Fill;
            pictureBoxFingerprint.Location = new Point(0, 0);
            pictureBoxFingerprint.Name = "pictureBoxFingerprint";
            pictureBoxFingerprint.Size = new Size(374, 580);
            pictureBoxFingerprint.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFingerprint.TabIndex = 0;
            pictureBoxFingerprint.TabStop = false;
            
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(52, 58, 115);
            panelRight.Controls.Add(lblCopyright);
            panelRight.Controls.Add(linkLabelSignup);
            panelRight.Controls.Add(lblClickHere);
            panelRight.Controls.Add(btnLogin);
            panelRight.Controls.Add(txtRole);
            panelRight.Controls.Add(lblRole);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(lblLoginPage);
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(pictureBoxIcon);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(374, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(426, 580);
            panelRight.TabIndex = 1;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 9F);
            lblCopyright.ForeColor = Color.White;
            lblCopyright.Location = new Point(60, 545);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(263, 20);
            lblCopyright.TabIndex = 12;
            lblCopyright.Text = "© Copyright — Kutumba Tech Pvt. Ltd.";
            // 
            // linkLabelSignup
            // 
            linkLabelSignup.AutoSize = true;
            linkLabelSignup.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            linkLabelSignup.LinkColor = Color.FromArgb(100, 149, 237);
            linkLabelSignup.Location = new Point(175, 497);
            linkLabelSignup.Name = "linkLabelSignup";
            linkLabelSignup.Size = new Size(80, 23);
            linkLabelSignup.TabIndex = 11;
            linkLabelSignup.TabStop = true;
            linkLabelSignup.Text = "Click here";
            linkLabelSignup.LinkClicked += linkLabelSignup_LinkClicked;
            // 
            // lblClickHere
            // 
            lblClickHere.AutoSize = true;
            lblClickHere.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblClickHere.ForeColor = Color.White;
            lblClickHere.Location = new Point(84, 474);
            lblClickHere.Name = "lblClickHere";
            lblClickHere.Size = new Size(242, 23);
            lblClickHere.TabIndex = 10;
            lblClickHere.Text = "Click here to create an account?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(88, 101, 242);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(60, 405);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 45);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtRole
            // 
            txtRole.Font = new Font("Segoe UI", 11F);
            txtRole.Location = new Point(60, 350);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(300, 32);
            txtRole.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(60, 321);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(56, 25);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role :";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(60, 270);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 32);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(60, 241);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password :";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(60, 190);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 32);
            txtUsername.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(60, 161);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 25);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Name : ";
            // 
            // lblLoginPage
            // 
            lblLoginPage.AutoSize = true;
            lblLoginPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLoginPage.ForeColor = Color.White;
            lblLoginPage.Location = new Point(142, 115);
            lblLoginPage.Name = "lblLoginPage";
            lblLoginPage.Size = new Size(116, 28);
            lblLoginPage.TabIndex = 2;
            lblLoginPage.Text = "Login Page";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(95, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Kutumba Hajiri";
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Location = new Point(30, 55);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(60, 60);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxFingerprint).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxFingerprint;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoginPage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblClickHere;
        private System.Windows.Forms.LinkLabel linkLabelSignup;
        private System.Windows.Forms.Label lblCopyright;
    }
}