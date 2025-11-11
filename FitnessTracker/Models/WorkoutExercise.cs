namespace FitnessTracker.Models;

public class WorkoutExercise: BaseEntity
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;
    public int Reps { get; set; }
    public double Weight { get; set; }
}