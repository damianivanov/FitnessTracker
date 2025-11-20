using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

public partial class LoginForm : Form
{
    private readonly AuthService _authService;
    private readonly Db _db;

    public User? LoggedInUser { get; private set; }

    public LoginForm(Db db)
    {
        _db = db;
        _authService = new AuthService(db);
        InitializeComponent();
        
        btnLogin.AddPrimaryHover();
    }

    /// <summary>
    /// Method to handle the main login logic
    /// </summary>
    private void btnLogin_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please enter both username and password.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var user = _authService.Login(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoggedInUser = user;
            AppSession.Login(user);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Method to handle the create an account logic to open the register form
    /// </summary>
    private void btnRegister_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm(_db);
        if (registerForm.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show("Registration successful! You can now login.", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Pre-fill username from registration
            if (registerForm.RegisteredUser != null)
            {
                txtUsername.Text = registerForm.RegisteredUser.Username;
                txtPassword.Focus();
            }
        }
    }

    /// <summary>
    /// Method to handle the enter key press in the password textbox
    /// </summary>
    private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            btnLogin_Click(sender, e);
        }
    }

    /// <summary>
    /// Method to add underline to the register link when hovered
    /// </summary>
    private void lblRegisterLink_MouseEnter(object sender, EventArgs e)
    {
        lblRegisterLink.Font = new Font(lblRegisterLink.Font, FontStyle.Underline);
    }

    private void lblRegisterLink_MouseLeave(object sender, EventArgs e)
    {
        lblRegisterLink.Font = new Font(lblRegisterLink.Font, FontStyle.Regular);
    }
}

