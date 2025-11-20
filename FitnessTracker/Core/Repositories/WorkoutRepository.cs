using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

/// <summary>
/// Repository for managing workout sessions
/// </summary>
public class WorkoutRepository: BaseRepository<Workout>
{
    /// <summary>
    /// Initializes the workout repository with indexes for efficient querying by user and date
    /// </summary>
    public WorkoutRepository(LiteDatabase db) : base(db, "Workouts")
    {
        // Index for fast user-based queries
        _collection.EnsureIndex(w => w.UserId);
        // Composite index for user + date queries
        _collection.EnsureIndex(w => new {w.UserId, w.Date});
    }
    
    /// <summary>
    /// Gets all workouts for a specific user
    /// </summary>
    public IEnumerable<Workout> GetByUserId(int userId) => _collection.Find(w => w.UserId == userId);
}