using System.Text.Json;
using FitnessTracker.Core;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public static class ExerciseSeeder
{
    public static void Seed(Db db, string? jsonPath = null)
    {
        jsonPath ??= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "initialExerciseTemplates.json");
        
        var repo = db.Exercises.GetAll();
        if(repo.Any()) return;
        if(!File.Exists(jsonPath)) 
        {
            Console.WriteLine($"Exercise seed file not found at: {jsonPath}");
            return;
        }
        
        using var stream = File.OpenRead(jsonPath);
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        
        var exercises = JsonSerializer.Deserialize<List<Exercise>>(stream, options) ?? throw new InvalidOperationException("Failed to deserialize exercise data.");
        
        foreach (var exercise in exercises)
        {
            if (repo.Any(e => e.Name == exercise.Name)) continue;
            db.Exercises.Insert(exercise);
        }
    }
}