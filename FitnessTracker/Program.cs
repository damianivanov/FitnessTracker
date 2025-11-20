// Дамян Николаев Иванов - ФН: F123976
using FitnessTracker.Core;
using FitnessTracker.Services;
using FitnessTracker.Forms;

namespace FitnessTracker;

// Main entry point for the Fitness Tracker application
static class Program
{
    /// <summary>
    /// Application entry point - initializes database, seeds exercises, and starts login flow
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Initialize Windows Forms application configuration
        ApplicationConfiguration.Initialize();

        // Initialize database connection
        using var db = new Db();
        
        // Seed initial exercise templates if database is empty
        ExerciseSeeder.Seed(db);
        
        // Show login form and exit if user cancels
        var loginForm = new LoginForm(db);
        if (loginForm.ShowDialog() != DialogResult.OK || loginForm.LoggedInUser == null)
        {
            return;
        }
        
        // Store logged-in user in session and launch main application
        var user = loginForm.LoggedInUser;
        AppSession.Login(user);
        Application.Run(new MainForm(db));
    }
}