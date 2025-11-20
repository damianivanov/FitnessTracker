namespace FitnessTracker.Models;

public class Workout: BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<WorkoutExercise> Exercises { get; set; } = [];
}