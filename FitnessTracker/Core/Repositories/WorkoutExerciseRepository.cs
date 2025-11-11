using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class WorkoutExerciseRepository: BaseRepository<WorkoutExercise>
{
    public WorkoutExerciseRepository(LiteDatabase db) : base(db,"WorkoutExercises")
    {
        _collection.EnsureIndex(u => u.Id, unique: true);
    }
}