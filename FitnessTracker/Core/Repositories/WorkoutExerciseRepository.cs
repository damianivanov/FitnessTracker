using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

/// <summary>
/// Repository for managing workout exercises (exercises within workouts)
/// </summary>
public class WorkoutExerciseRepository: BaseRepository<WorkoutExercise>
{
    /// <summary>
    /// Initializes the workout exercise repository
    /// </summary>
    public WorkoutExerciseRepository(LiteDatabase db) : base(db,"WorkoutExercises")
    {
        // Ensure unique IDs (already done in base, but explicitly stated)
        _collection.EnsureIndex(u => u.Id, unique: true);
    }
}