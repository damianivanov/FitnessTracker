using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

public partial class MainForm : Form
{
    private readonly Db _db;
    private readonly WorkoutService _workoutService;

    public MainForm(Db db)
    {
        _db = db;
        _workoutService = new WorkoutService(db);
        InitializeComponent();
        LoadUserInfo();
    }

    private void LoadUserInfo()
    {
        if (AppSession.CurrentUser == null) return;
        lblWelcome.Text = $"Welcome, @{AppSession.CurrentUser.Name}!";
        LoadWorkouts();
    }

    private void LoadWorkouts()
    {
        if (AppSession.CurrentUser == null) return;

        flpWorkouts.Controls.Clear();
        var workouts = _workoutService.GetWorkouts(AppSession.CurrentUserId);

        foreach (var workout in workouts)
        {
            var workoutCard = CreateWorkoutCard(workout);
            flpWorkouts.Controls.Add(workoutCard);
        }
    }

    private Panel CreateWorkoutCard(Workout workout)
    {
        var cardWidth = flpWorkouts.Width - 20;
        var card = new Panel
        {
            MinimumSize = new Size(cardWidth, 130),
            BackColor = UiConstants.Colors.BackgroundMedium,
            Padding = new Padding(20, 15, 20, 15),
            Cursor = Cursors.Hand,
            Tag = workout
        };

        // Workout Name - Top Left
        var lblName = new Label
        {
            Text = workout.Name,
            Font = new Font("Segue UI", 18F, FontStyle.Bold),
            ForeColor = UiConstants.Colors.TextPrimary,
            AutoSize = true,
            Location = new Point(15, 15)
        };

        // Date - Top Right
        var lblDate = new Label
        {
            Text = workout.Date.ToString("MMM dd, yyyy"),
            Font = new Font("Segue UI", 12F),
            ForeColor = UiConstants.Colors.TextSecondary,
            AutoSize = true
        };
        lblDate.Location = new Point(cardWidth - lblDate.PreferredWidth - 15, 15);

        // Exercise List - Middle (wrapping flow layout)
        var flpExercises = new FlowLayoutPanel
        {
            Location = new Point(15, 50),
            Width = cardWidth - 30,
            Height = 40,
            AutoSize = false,
            WrapContents = true,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Transparent
        };

        foreach (var exercise in workout.Exercises)
        {
            var lblExercise = new Label
            {
                Text = $"• {exercise.ExerciseName}: {exercise.Reps} × {exercise.Weight} kg",
                Font = new Font("Segue UI", 10F),
                ForeColor = UiConstants.Colors.TextSecondary,
                AutoSize = true,
                Margin = new Padding(0, 0, 15, 5)
            };
            flpExercises.Controls.Add(lblExercise);
        }

        // Total Volume - Bottom Right
        var lblVolume = new Label
        {
            Text = $"Total Volume: {WorkoutService.ComputeVolume(workout):F1} kg",
            Font = new Font("Segue UI", 10F, FontStyle.Bold),
            ForeColor = UiConstants.Colors.Success,
            AutoSize = true
        };
        lblVolume.Location = new Point(cardWidth - lblVolume.PreferredWidth - 15, 90);

        card.Controls.Add(lblName);
        card.Controls.Add(lblDate);
        card.Controls.Add(flpExercises);
        card.Controls.Add(lblVolume);

        // Hover effect
        card.MouseEnter += (s, e) => card.BackColor = UiConstants.Colors.BackgroundLight;
        card.MouseLeave += (s, e) => card.BackColor = UiConstants.Colors.BackgroundMedium;

        return card;
    }

    private void btnAddWorkout_Click(object sender, EventArgs e)
    {
        var addWorkoutForm = new AddWorkoutForm(_db);
        if (addWorkoutForm.ShowDialog() == DialogResult.OK)
        {
            LoadWorkouts();
        }
    }


    private void btnLogout_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to logout?", "Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            AppSession.Logout();
            Application.Restart();
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        AppSession.Logout();
    }
}

