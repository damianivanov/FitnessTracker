using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

public partial class AddWorkoutForm : Form
{
    private readonly Db _db;
    private readonly WorkoutService _workoutService;
    private List<WorkoutExercise> _exercises = new();

    public AddWorkoutForm(Db db)
    {
        _db = db;
        _workoutService = new WorkoutService(db);
        InitializeComponent();
        dtpWorkoutDate.Value = DateTime.Today;
    }

    private void RefreshExerciseList()
    {
        flpExercises.Controls.Clear();

        foreach (var exercise in _exercises)
        {
            var exerciseCard = CreateExerciseCard(exercise);
            flpExercises.Controls.Add(exerciseCard);
        }
    }

    private Panel CreateExerciseCard(WorkoutExercise exercise)
    {
        var cardWidth = (flpExercises.ClientSize.Width - 40) / 2;
        var card = new Panel
        {
            Width = cardWidth,
            Height = 80,
            BackColor = UiConstants.Colors.BackgroundMedium,
            Margin = new Padding(0, 0, 20, 10),
            Padding = new Padding(15, 10, 15, 10),
            Tag = exercise
        };

        // Exercise Name
        var lblName = new Label
        {
            Text = exercise.ExerciseName,
            AutoSize = true,
            Location = new Point(15, 12)
        };
        lblName.StyleLabel();

        // Exercise Details
        var lblDetails = new Label
        {
            Text = $"Reps: {exercise.Reps}  |  Weight: {exercise.Weight:F1} kg",
            Font = new Font("Segue UI", 10F),
            ForeColor = UiConstants.Colors.TextSecondary,
            AutoSize = true,
            Location = new Point(15, 42)
        };

        // Remove Button (X)
        var btnRemove = new Button
        {
            Text = "×",
            Font = new Font("Segue UI", 18F, FontStyle.Bold),
            Size = new Size(40, 40),
            Location = new Point(615, 20),
            Tag = exercise
        };
        btnRemove.StyleDanger();
        btnRemove.Click += (_, _) => RemoveExerciseFromList(exercise);

        card.Controls.Add(lblName);
        card.Controls.Add(lblDetails);
        card.Controls.Add(btnRemove);

        return card;
    }

    private void RemoveExerciseFromList(WorkoutExercise exercise)
    {
        var result = MessageBox.Show("Are you sure you want to remove this exercise?", 
            "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _exercises.Remove(exercise);
            RefreshExerciseList();
        }
    }

    private void btnAddExercise_Click(object sender, EventArgs e)
    {
        var addExerciseDialog = new AddExerciseDialog(_db);
        if (addExerciseDialog.ShowDialog(this) != DialogResult.OK) return;
        var newExercise = addExerciseDialog.WorkoutExercise;
        if (newExercise == null) return;
        _exercises.Add(newExercise);
        RefreshExerciseList();
    }

    private void btnRemoveExercise_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Click the × button on an exercise card to remove it.", "Info", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtWorkoutName.Text))
        {
            MessageBox.Show("Please enter a workout name.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtWorkoutName.Focus();
            return;
        }

        if (_exercises.Count == 0)
        {
            var result = MessageBox.Show("You haven't added any exercises. Do you want to save anyway?", 
                "No Exercises", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
        }

        try
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("User session expired. Please login again.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Create a new workout
            var workout = _workoutService.CreateWorkout(
                AppSession.CurrentUser.Id, 
                txtWorkoutName.Text.Trim(), 
                dtpWorkoutDate.Value);

            // Add exercises to the workout
            foreach (var exercise in _exercises)
            {
                _workoutService.AddExercise(workout.Id, exercise.ExerciseId, 
                    exercise.Reps, exercise.Weight);
            }

            MessageBox.Show("Workout created successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving workout: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

