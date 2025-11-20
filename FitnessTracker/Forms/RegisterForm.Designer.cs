using FitnessTracker.UI;
using System.Windows.Forms;
namespace FitnessTracker.Forms;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblName;
    private Label lblUsername;
    private Label lblPassword;
    private Label lblConfirmPassword;
    private TextBox txtName;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private TextBox txtConfirmPassword;
    private Button btnRegister;
    private Panel panelMain;

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
        lblTitle = new Label();
        lblName = new Label();
        lblUsername = new Label();
        lblPassword = new Label();
        lblConfirmPassword = new Label();
        txtName = new TextBox();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        txtConfirmPassword = new TextBox();
        btnRegister = new Button();
        panelMain = new Panel();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Segue UI", 24F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = UiConstants.Colors.TextPrimary;
        lblTitle.Location = new System.Drawing.Point(0, 50);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(540, 50);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Create New Account";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblName
        // 
        lblName.StyleLabel();
        lblName.AutoSize = true;
        lblName.Location = new System.Drawing.Point(100, 130);
        lblName.Name = "lblName";
        lblName.Size = new System.Drawing.Size(55, 21);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";
        // 
        // lblUsername
        // 
        lblUsername.StyleLabel();
        lblUsername.AutoSize = true;
        lblUsername.Location = new System.Drawing.Point(100, 215);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new System.Drawing.Size(84, 21);
        lblUsername.TabIndex = 3;
        lblUsername.Text = "Username:";
        // 
        // lblPassword
        // 
        lblPassword.StyleLabel();
        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(100, 305);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new System.Drawing.Size(79, 21);
        lblPassword.TabIndex = 5;
        lblPassword.Text = "Password:";
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.StyleLabel();
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new System.Drawing.Point(100, 395);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new System.Drawing.Size(141, 21);
        lblConfirmPassword.TabIndex = 7;
        lblConfirmPassword.Text = "Confirm Password:";
        // 
        // txtName
        // 
        txtName.StyleInput();
        txtName.Location = new System.Drawing.Point(100, 160);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(340, 25);
        txtName.TabIndex = 2;
        // 
        // txtUsername
        // 
        txtUsername.StyleInput();
        txtUsername.Location = new System.Drawing.Point(100, 245);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new System.Drawing.Size(340, 25);
        txtUsername.TabIndex = 4;
        // 
        // txtPassword
        // 
        txtPassword.StyleInput();
        txtPassword.Location = new System.Drawing.Point(100, 335);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new System.Drawing.Size(340, 25);
        txtPassword.TabIndex = 6;
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.StyleInput();
        txtConfirmPassword.Location = new System.Drawing.Point(100, 425);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.Size = new System.Drawing.Size(340, 25);
        txtConfirmPassword.TabIndex = 8;
        txtConfirmPassword.KeyPress += txtConfirmPassword_KeyPress;
        // 
        // btnRegister
        // 
        btnRegister.StylePrimary();
        btnRegister.Location = new System.Drawing.Point(100, 490);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new System.Drawing.Size(340, 45);
        btnRegister.TabIndex = 9;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click += btnRegister_Click;
        // 
        // panelMain
        // 
        panelMain.BackColor = UiConstants.Colors.BackgroundDark;
        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblName);
        panelMain.Controls.Add(txtName);
        panelMain.Controls.Add(lblUsername);
        panelMain.Controls.Add(txtUsername);
        panelMain.Controls.Add(lblPassword);
        panelMain.Controls.Add(txtPassword);
        panelMain.Controls.Add(lblConfirmPassword);
        panelMain.Controls.Add(txtConfirmPassword);
        panelMain.Controls.Add(btnRegister);
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(540, 600);
        panelMain.TabIndex = 0;
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(540, 600);
        Controls.Add(panelMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Register - Fitness Tracker";
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
}

