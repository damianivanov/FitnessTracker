using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

public partial class RegisterForm : Form
{
    private readonly AuthService _authService;

    public User? RegisteredUser { get; private set; }

    public RegisterForm(Db db)
    {
        _authService = new AuthService(db);
        InitializeComponent();
        
        // Add hover effect to register button
        btnRegister.AddPrimaryHover();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        // Validation
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Please enter your name.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("Please enter a username.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (username.Length < 3)
        {
            MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please enter a password.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        if (password.Length < 4)
        {
            MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Passwords do not match.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        try
        {
            RegisteredUser = _authService.Register(name, username, password);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Registration Failed", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            btnRegister_Click(sender, e);
        }
    }
}

