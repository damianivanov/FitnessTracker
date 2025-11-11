namespace FitnessTracker.Models;

public class Workout: BaseEntity
{
    public int UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<WorkoutExercise> Exercises { get; set; } = [];
}