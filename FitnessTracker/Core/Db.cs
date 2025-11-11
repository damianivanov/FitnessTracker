using FitnessTracker.Core.Repositories;
using LiteDB;

namespace FitnessTracker.Core;

public sealed class Db: IDisposable
{
    private readonly LiteDatabase _db;
    public UserRepository Users { get; }
    public ExerciseRepository Exercises { get; }
    public WorkoutRepository Workouts { get; }
    public WorkoutExerciseRepository WorkoutExercises { get; }

    public Db(string dbPath = "database.db")
    {
        _db = new LiteDatabase(dbPath);
        Users = new UserRepository(_db);
        Exercises = new ExerciseRepository(_db);
        Workouts = new WorkoutRepository(_db);
        WorkoutExercises = new WorkoutExerciseRepository(_db);
    }
    
    public void Dispose() => _db.Dispose();
}