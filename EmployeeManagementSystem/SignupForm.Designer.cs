namespace EmployeeManagementSystem.Forms
{
    partial class SignupForm
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
            linkLabelLogin = new LinkLabel();
            lblClickHere = new Label();
            btnSignup = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblRegisterPage = new Label();
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
            panelLeft.Size = new Size(374, 600);
            panelLeft.TabIndex = 0;
            // 
            // pictureBoxFingerprint
            // 
            pictureBoxFingerprint.Dock = DockStyle.Fill;
            pictureBoxFingerprint.Location = new Point(0, 0);
            pictureBoxFingerprint.Name = "pictureBoxFingerprint";
            pictureBoxFingerprint.Size = new Size(374, 600);
            pictureBoxFingerprint.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFingerprint.TabIndex = 0;
            pictureBoxFingerprint.TabStop = false;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(52, 58, 115);
            panelRight.Controls.Add(lblCopyright);
            panelRight.Controls.Add(linkLabelLogin);
            panelRight.Controls.Add(lblClickHere);
            panelRight.Controls.Add(btnSignup);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtEmail);
            panelRight.Controls.Add(lblEmail);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(lblRegisterPage);
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(pictureBoxIcon);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(374, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(402, 600);
            panelRight.TabIndex = 1;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 9F);
            lblCopyright.ForeColor = Color.White;
            lblCopyright.Location = new Point(60, 565);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(263, 20);
            lblCopyright.TabIndex = 12;
            lblCopyright.Text = "© Copyright — Kutumba Tech Pvt. Ltd.";
            // 
            // linkLabelLogin
            // 
            linkLabelLogin.AutoSize = true;
            linkLabelLogin.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            linkLabelLogin.LinkColor = Color.FromArgb(100, 149, 237);
            linkLabelLogin.Location = new Point(175, 512);
            linkLabelLogin.Name = "linkLabelLogin";
            linkLabelLogin.Size = new Size(80, 23);
            linkLabelLogin.TabIndex = 11;
            linkLabelLogin.TabStop = true;
            linkLabelLogin.Text = "Click here";
            linkLabelLogin.LinkClicked += linkLabelLogin_LinkClicked;
            // 
            // lblClickHere
            // 
            lblClickHere.AutoSize = true;
            lblClickHere.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblClickHere.ForeColor = Color.White;
            lblClickHere.Location = new Point(77, 489);
            lblClickHere.Name = "lblClickHere";
            lblClickHere.Size = new Size(221, 23);
            lblClickHere.TabIndex = 10;
            lblClickHere.Text = "Already have an an account?";
            // 
            // btnSignup
            // 
            btnSignup.BackColor = Color.FromArgb(88, 101, 242);
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSignup.ForeColor = Color.White;
            btnSignup.Location = new Point(60, 420);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(300, 45);
            btnSignup.TabIndex = 9;
            btnSignup.Text = "Register";
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(60, 350);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 32);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(60, 321);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 25);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password :";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(60, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 32);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(60, 241);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email :";
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
            // lblRegisterPage
            // 
            lblRegisterPage.AutoSize = true;
            lblRegisterPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRegisterPage.ForeColor = Color.White;
            lblRegisterPage.Location = new Point(125, 115);
            lblRegisterPage.Name = "lblRegisterPage";
            lblRegisterPage.Size = new Size(142, 28);
            lblRegisterPage.TabIndex = 2;
            lblRegisterPage.Text = "Register Page";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(134, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Register";
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
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 600);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SignupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += SignupForm_Load;
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
        private System.Windows.Forms.Label lblRegisterPage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lblClickHere;
        private System.Windows.Forms.LinkLabel linkLabelLogin;
        private System.Windows.Forms.Label lblCopyright;
    }
}