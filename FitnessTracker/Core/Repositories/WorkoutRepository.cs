using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class WorkoutRepository: BaseRepository<Workout>
{
    public WorkoutRepository(LiteDatabase db) : base(db, "Workouts")
    {
        _collection.EnsureIndex(w => w.UserId);
        _collection.EnsureIndex(w => new {w.UserId, w.Date});
    }
    
    public IEnumerable<Workout> GetByUserId(int userId) => _collection.Find(w => w.UserId == userId);
}