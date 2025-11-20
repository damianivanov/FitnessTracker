using FitnessTracker.UI;
using System.Windows.Forms;
using System.Drawing;

namespace FitnessTracker.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitle;
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label lblRegisterLink;
    private System.Windows.Forms.Panel panelMain;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitle = new System.Windows.Forms.Label();
        lblUsername = new System.Windows.Forms.Label();
        lblPassword = new System.Windows.Forms.Label();
        txtUsername = new System.Windows.Forms.TextBox();
        txtPassword = new System.Windows.Forms.TextBox();
        btnLogin = new System.Windows.Forms.Button();
        lblRegisterLink = new System.Windows.Forms.Label();
        panelMain = new System.Windows.Forms.Panel();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = UiConstants.Colors.TextPrimary;
        lblTitle.Location = new System.Drawing.Point(0, 53);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(540, 70);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Fitness Tracker";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblUsername
        // 
        lblUsername.StyleLabel();
        lblUsername.AutoSize = true;
        lblUsername.Location = new System.Drawing.Point(100, 150);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new System.Drawing.Size(74, 19);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "Username:";
        // 
        // txtUsername
        // 
        txtUsername.StyleInput();
        txtUsername.Location = new System.Drawing.Point(100, 172);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new System.Drawing.Size(340, 25);
        txtUsername.TabIndex = 2;
        // 
        // lblPassword
        // 
        lblPassword.StyleLabel();
        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(100, 225);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new System.Drawing.Size(70, 19);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Password:";
        // 
        // txtPassword
        // 
        txtPassword.StyleInput();
        txtPassword.Location = new System.Drawing.Point(100, 250);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new System.Drawing.Size(340, 25);
        txtPassword.TabIndex = 4;
        txtPassword.KeyPress += txtPassword_KeyPress;
        // 
        // btnLogin
        // 
        btnLogin.StylePrimary();
        btnLogin.Location = new System.Drawing.Point(100, 315);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new System.Drawing.Size(340, 40);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += btnLogin_Click;
        // 
        // lblRegisterLink
        // 
        lblRegisterLink.Cursor = System.Windows.Forms.Cursors.Hand;
        lblRegisterLink.Font = new System.Drawing.Font("Segue UI", 10F);
        lblRegisterLink.ForeColor = UiConstants.Colors.Primary;
        lblRegisterLink.Location = new System.Drawing.Point(100, 370);
        lblRegisterLink.Name = "lblRegisterLink";
        lblRegisterLink.Size = new System.Drawing.Size(340, 19);
        lblRegisterLink.TabIndex = 6;
        lblRegisterLink.Text = "Create an account";
        lblRegisterLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lblRegisterLink.Click += btnRegister_Click;
        lblRegisterLink.MouseEnter += lblRegisterLink_MouseEnter;
        lblRegisterLink.MouseLeave += lblRegisterLink_MouseLeave;
        // 
        // panelMain
        // 
        panelMain.BackColor = UiConstants.Colors.BackgroundDark;
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblUsername);
        panelMain.Controls.Add(txtUsername);
        panelMain.Controls.Add(lblPassword);
        panelMain.Controls.Add(txtPassword);
        panelMain.Controls.Add(btnLogin);
        panelMain.Controls.Add(lblRegisterLink);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(540, 600);
        panelMain.TabIndex = 0;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(540, 450);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = true;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Login - Fitness Tracker";
        panelMain.ResumeLayout(true);
        panelMain.PerformLayout();
        ResumeLayout(true);
    }
}

