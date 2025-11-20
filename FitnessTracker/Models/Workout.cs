// Дамян Николаев Иванов - ФН: F123976
namespace FitnessTracker.Models;

/// <summary>
/// Represents a workout session containing multiple exercises with reps and weights
/// </summary>
public class Workout: BaseEntity
{
    /// <summary>
    /// ID of the user who owns this workout
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Name/title of the workout (e.g., "Leg Day", "Upper Body")
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Date when the workout was performed
    /// </summary>
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// List of exercises performed in this workout with their reps and weights
    /// </summary>
    public List<WorkoutExercise> Exercises { get; set; } = [];
}