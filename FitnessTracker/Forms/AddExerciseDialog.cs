using FitnessTracker.Core;
using FitnessTracker.Models;

namespace FitnessTracker.Forms;

public partial class AddExerciseDialog : Form
{
    private readonly Db _db;
    private List<Exercise>? _exercises;

    public WorkoutExercise? WorkoutExercise { get; private set; }

    public AddExerciseDialog(Db db)
    {
        _db = db;
        InitializeComponent();
        LoadExercises();
    }

    private void LoadExercises()
    {
        _exercises = _db.Exercises.GetAll().ToList();
        
        if (_exercises.Count == 0)
        {
            MessageBox.Show("No exercises found in the database. Please add some exercises first.", 
                "No Exercises", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        cmbExercise.DataSource = _exercises;
        cmbExercise.DisplayMember = "Name";
        cmbExercise.ValueMember = "Id";
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (cmbExercise.SelectedItem == null)
        {
            MessageBox.Show("Please select an exercise.", "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedExercise = (Exercise)cmbExercise.SelectedItem;

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

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

