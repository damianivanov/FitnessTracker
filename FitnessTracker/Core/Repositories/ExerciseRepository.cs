using FitnessTracker.Core.Interfaces;
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class ExerciseRepository: BaseRepository<Exercise>
{
    public ExerciseRepository(LiteDatabase db) : base(db, "Exercises")
    {
        _collection.EnsureIndex(e => e.Name, unique: true);
    }
    public Exercise? GetByName(string name) => _collection.FindOne(e => e.Name == name);
    public IEnumerable<Exercise> GetByMuscleGroup(string muscleGroup) => _collection.Find(e => e.MuscleGroup == muscleGroup);
    public IEnumerable<Exercise> GetBySecondaryMuscleGroup(string secondaryMuscleGroup) => _collection.Find(e => e.SecondaryMuscleGroup == secondaryMuscleGroup);
    public IEnumerable<Exercise> GetByCategory(string category) => _collection.Find(e => e.Category == category);
}