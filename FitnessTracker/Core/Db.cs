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

    public Db(string? dbPath = null)
    {
        dbPath ??= GetDefaultDatabasePath();
        _db = new LiteDatabase(dbPath);
        Users = new UserRepository(_db);
        Exercises = new ExerciseRepository(_db);
        Workouts = new WorkoutRepository(_db);
        WorkoutExercises = new WorkoutExerciseRepository(_db);
    }
    
    private static string GetDefaultDatabasePath()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, "..", "..", "..", ".."));
        var dbDirectory = Path.Combine(projectRoot, "FitnessTracker", "Core");
        return Path.Combine(dbDirectory, "database.db");
    }
    
    public void Dispose() => _db.Dispose();
}