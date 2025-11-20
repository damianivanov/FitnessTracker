using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

/// <summary>
/// Login form for user authentication and registration navigation
/// </summary>
public partial class LoginForm : Form
{
    private readonly AuthService _authService;
    private readonly Db _db;

    /// <summary>
    /// The successfully logged in user, or null if login was cancelled
    /// </summary>
    public User? LoggedInUser { get; private set; }

    /// <summary>
    /// Initializes the login form with database connection
    /// </summary>
    public LoginForm(Db db)
    {
        _db = db;
        _authService = new AuthService(db);
        InitializeComponent();
        
        // Add hover effect to login button
        btnLogin.AddPrimaryHover();
    }

    /// <summary>
    /// Handles login button click - validates credentials and authenticates user
    /// </summary>
    private void btnLogin_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        // Validate input fields
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please enter both username and password.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Attempt to authenticate user
            var user = _authService.Login(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set logged in user and close form with OK result
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
    /// Opens the registration form for new user account creation
    /// </summary>
    private void btnRegister_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm(_db);
        if (registerForm.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show("Registration successful! You can now login.", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Pre-fill username from registration for convenience
            if (registerForm.RegisteredUser != null)
            {
                txtUsername.Text = registerForm.RegisteredUser.Username;
                txtPassword.Focus();
            }
        }
    }

    /// <summary>
    /// Allows Enter key in password field to trigger login
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
    /// Adds underline effect when hovering over register link
    /// </summary>
    private void lblRegisterLink_MouseEnter(object sender, EventArgs e)
    {
        lblRegisterLink.Font = new Font(lblRegisterLink.Font, FontStyle.Underline);
    }

    /// <summary>
    /// Removes underline when mouse leaves register link
    /// </summary>
    private void lblRegisterLink_MouseLeave(object sender, EventArgs e)
    {
        lblRegisterLink.Font = new Font(lblRegisterLink.Font, FontStyle.Regular);
    }
}

