// Дамян Николаев Иванов - ФН: F123976
namespace FitnessTracker.Models;

/// <summary>
/// Represents an exercise template with metadata like muscle groups and categories
/// </summary>
public class Exercise: BaseEntity
{
    /// <summary>
    /// Name of the exercise (e.g., "Bench Press", "Squat")
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Primary muscle group targeted by the exercise (e.g., "Chest", "Legs")
    /// </summary>
    public string MuscleGroup { get; set; } = string.Empty;
    
    /// <summary>
    /// Secondary muscle group involved in the exercise
    /// </summary>
    public string SecondaryMuscleGroup { get; set; } = string.Empty;
    
    /// <summary>
    /// Category of the exercise (e.g., "Strength", "Cardio")
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// URL to an image/photo demonstrating the exercise
    /// </summary>
    public string PhotoUrl { get; set; } = string.Empty;
}