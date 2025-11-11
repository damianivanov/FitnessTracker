using FitnessTracker.Core.Interfaces;
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class ExerciseRepository: BaseRepository<Exercise>
{
    public ExerciseRepository(LiteDatabase db) : base(db, "Exercises")
    {
        _collection.EnsureIndex(e => e.Code, unique: true);
    }
}