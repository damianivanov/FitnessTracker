using FitnessTracker.Core;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.UI;

namespace FitnessTracker.Forms;

/// <summary>
/// Form for creating a new workout with exercises, reps, and weights
/// </summary>
public partial class AddWorkoutForm : Form
{
    private readonly Db _db;
    private readonly WorkoutService _workoutService;
    
    /// <summary>
    /// List of exercises being added to this workout
    /// </summary>
    private List<WorkoutExercise> _exercises = new();

    /// <summary>
    /// Initializes the Add Workout form
    /// </summary>
    public AddWorkoutForm(Db db)
    {
        _db = db;
        _workoutService = new WorkoutService(db);
        InitializeComponent();
        dtpWorkoutDate.Value = DateTime.Today;
    }

    /// <summary>
    /// Refreshes the visual display of exercises in the workout
    /// </summary>
    private void RefreshExerciseList()
    {
        flpExercises.Controls.Clear();

        foreach (var exercise in _exercises)
        {
            var exerciseCard = CreateExerciseCard(exercise);
            flpExercises.Controls.Add(exerciseCard);
        }
    }

    /// <summary>
    /// Creates a visual card for a single exercise in the workout
    /// </summary>
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

    /// <summary>
    /// Removes an exercise from the workout after confirmation
    /// </summary>
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

    /// <summary>
    /// Opens dialog to add a new exercise to the workout
    /// </summary>
    private void btnAddExercise_Click(object sender, EventArgs e)
    {
        var addExerciseDialog = new AddExerciseDialog(_db);
        if (addExerciseDialog.ShowDialog(this) != DialogResult.OK) return;
        var newExercise = addExerciseDialog.WorkoutExercise;
        if (newExercise == null) return;
        _exercises.Add(newExercise);
        RefreshExerciseList();
    }

    /// <summary>
    /// Shows info message about how to remove exercises
    /// </summary>
    private void btnRemoveExercise_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Click the × button on an exercise card to remove it.", "Info", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Validates and saves the workout to the database
    /// </summary>
    private void btnSave_Click(object sender, EventArgs e)
    {
        // Validate workout name
        if (string.IsNullOrWhiteSpace(txtWorkoutName.Text))
        {
            MessageBox.Show("Please enter a workout name.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtWorkoutName.Focus();
            return;
        }

        // Warn if no exercises added
        if (_exercises.Count == 0)
        {
            var result = MessageBox.Show("You haven't added any exercises. Do you want to save anyway?", 
                "No Exercises", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
        }

        try
        {
            // Verify user session is still valid
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

            // Add all exercises to the workout
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

    /// <summary>
    /// Cancels workout creation and closes the form
    /// </summary>
    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

