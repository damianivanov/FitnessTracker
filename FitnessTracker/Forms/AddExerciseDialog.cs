using FitnessTracker.Core;
using FitnessTracker.Models;

namespace FitnessTracker.Forms;

/// <summary>
/// Dialog that allows selecting an exercise and specifying reps and weight
/// </summary>
public partial class AddExerciseDialog : Form
{
    private readonly Db _db;
    private List<Exercise>? _exercises;

    /// <summary>
    /// The created workout exercise with selected exercise, reps, and weight
    /// </summary>
    public WorkoutExercise? WorkoutExercise { get; private set; }

    /// <summary>
    /// Initializes the Add Exercise dialog
    /// </summary>
    public AddExerciseDialog(Db db)
    {
        _db = db;
        InitializeComponent();
        LoadExercises();
    }

    /// <summary>
    /// Loads all available exercises from the database into the dropdown
    /// </summary>
    private void LoadExercises()
    {
        _exercises = _db.Exercises.GetAll().ToList();
        
        // Check if any exercises exist
        if (_exercises.Count == 0)
        {
            MessageBox.Show("No exercises found in the database. Please add some exercises first.", 
                "No Exercises", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        // Populate dropdown with exercises
        cmbExercise.DataSource = _exercises;
        cmbExercise.DisplayMember = "Name";
        cmbExercise.ValueMember = "Id";
    }

    /// <summary>
    /// Creates a workout exercise based on the selected exercise, reps, and weight
    /// </summary>
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Validate exercise selection
        if (cmbExercise.SelectedItem == null)
        {
            MessageBox.Show("Please select an exercise.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedExercise = (Exercise)cmbExercise.SelectedItem;

        // Create workout exercise based on the selected values
        WorkoutExercise = new WorkoutExercise
        {
            ExerciseId = selectedExercise.Id,
            ExerciseName = selectedExercise.Name,
            Reps = (int)nudReps.Value,
            Weight = (double)nudWeight.Value
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    /// <summary>
    /// Cancels exercise selection and closes the dialog
    /// </summary>
    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

