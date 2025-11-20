// Дамян Николаев Иванов - ФН: F123976
using FitnessTracker.Core.Repositories;
using LiteDB;

namespace FitnessTracker.Core;

// Database context that provides access to all repositories and manages the LiteDB connection
public sealed class Db: IDisposable
{
    private readonly LiteDatabase _db;
    
    /// <summary>
    /// Repository for user operations
    /// </summary>
    public UserRepository Users { get; }
    
    /// <summary>
    /// Repository for exercise template operations
    /// </summary>
    public ExerciseRepository Exercises { get; }
    
    /// <summary>
    /// Repository that manages workout operations
    /// </summary>
    public WorkoutRepository Workouts { get; }
    
    /// <summary>
    /// Repository that manages workout exercise operations
    /// </summary>
    public WorkoutExerciseRepository WorkoutExercises { get; }

    /// <summary>
    /// Initializes the database connection and all repositories
    /// </summary>
    /// <param name="dbPath">Optional custom database path, defaults to project Core folder</param>
    public Db(string? dbPath = null)
    {
        dbPath ??= GetDefaultDatabasePath();
        _db = new LiteDatabase(dbPath);
        Users = new UserRepository(_db);
        Exercises = new ExerciseRepository(_db);
        Workouts = new WorkoutRepository(_db);
        WorkoutExercises = new WorkoutExerciseRepository(_db);
    }
    
    /// <summary>
    /// Gets the default database path in the project's Core directory
    /// </summary>
    private static string GetDefaultDatabasePath()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, "..", "..", "..", ".."));
        var dbDirectory = Path.Combine(projectRoot, "FitnessTracker", "Core");
        return Path.Combine(dbDirectory, "database.db");
    }
    
    public void Dispose() => _db.Dispose();
}