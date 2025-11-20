using System.Text.Json;
using FitnessTracker.Core;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

/// <summary>
/// Service for seeding the database with initial exercise templates from JSON file
/// </summary>
public static class ExerciseSeeder
{
    /// <summary>
    /// Seeds the database with exercise templates if the database is empty
    /// </summary>
    /// <param name="db">Database instance</param>
    /// <param name="jsonPath">Optional custom path to JSON seed file</param>
    public static void Seed(Db db, string? jsonPath = null)
    {
        // Default to Assets folder if no path provided
        jsonPath ??= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "initialExerciseTemplates.json");
        
        // Get existing exercises
        var repo = db.Exercises.GetAll();
        
        // Skip seeding if exercises already exist
        if(repo.Any()) return;
        
        // Check if seed file exists
        if(!File.Exists(jsonPath)) 
        {
            Console.WriteLine($"Exercise seed file not found at: {jsonPath}");
            return;
        }
        
        // Open and read the JSON file
        using var stream = File.OpenRead(jsonPath);
        
        // Configure JSON deserialization options
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        
        // Deserialize exercise list from JSON
        var exercises = JsonSerializer.Deserialize<List<Exercise>>(stream, options) ?? throw new InvalidOperationException("Failed to deserialize exercise data.");
        
        // Insert each exercise into the database
        foreach (var exercise in exercises)
        {
            if (repo.Any(e => e.Name == exercise.Name)) continue;
            db.Exercises.Insert(exercise);
        }
    }
}