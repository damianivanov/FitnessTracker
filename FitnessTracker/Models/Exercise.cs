namespace FitnessTracker.Models;

public class Exercise: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string MuscleGroup { get; set; } = string.Empty;
    public string SecondaryMuscleGroup { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
}