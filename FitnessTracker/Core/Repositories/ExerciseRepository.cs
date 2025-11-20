using FitnessTracker.Core.Interfaces;
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

/// <summary>
/// Repository for managing exercise templates with specific query methods
/// </summary>
public class ExerciseRepository: BaseRepository<Exercise>
{
    /// <summary>
    /// Initializes the exercise repository with unique index on Name
    /// </summary>
    public ExerciseRepository(LiteDatabase db) : base(db, "Exercises")
    {
        // Exercise names must be unique
        _collection.EnsureIndex(e => e.Name, unique: true);
    }
    
    /// <summary>
    /// Finds an exercise by its name
    /// </summary>
    public Exercise? GetByName(string name) => _collection.FindOne(e => e.Name == name);
}