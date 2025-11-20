using FitnessTracker.Core;
using FitnessTracker.Services;
using FitnessTracker.Forms;

namespace FitnessTracker;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var db = new Db();
        ExerciseSeeder.Seed(db);
        
        var loginForm = new LoginForm(db);
        if (loginForm.ShowDialog() != DialogResult.OK || loginForm.LoggedInUser == null)
        {
            return;
        }
        var user = loginForm.LoggedInUser;
        AppSession.Login(user);
        Application.Run(new MainForm(db));
    }
}