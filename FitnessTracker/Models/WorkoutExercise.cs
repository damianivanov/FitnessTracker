// Дамян Николаев Иванов - ФН: F123976
namespace FitnessTracker.Models;

/// <summary>
/// Represents a single exercise performed within a workout with specific reps and weight
/// </summary>
public class WorkoutExercise: BaseEntity
{
    /// <summary>
    /// Reference to the Exercise template this is based on
    /// </summary>
    public int ExerciseId { get; set; }
    
    /// <summary>
    /// Name of the exercise (cached for quick display)
    /// </summary>
    public string ExerciseName { get; set; } = string.Empty;
    
    /// <summary>
    /// Number of repetitions performed
    /// </summary>
    public int Reps { get; set; }
    
    /// <summary>
    /// Weight used in kilograms
    /// </summary>
    public double Weight { get; set; }
}