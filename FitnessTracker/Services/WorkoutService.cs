using FitnessTracker.Core;
using FitnessTracker.Core.Repositories;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public class WorkoutService
{
    private readonly WorkoutRepository _workouts;
    private readonly ExerciseRepository _exercises;

    public WorkoutService(Db db)
    {
        _workouts = db.Workouts;
        _exercises = db.Exercises;
    }

    /// <summary>
    /// Creates a new workout for a user with a name and date (defaults to today).
    /// Returns the created workout with its ID.
    /// </summary>
    public Workout CreateWorkout(int userId, string name, DateTime? date = null)
    {
        if (userId <= 0) throw new ArgumentException("Invalid user id.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Workout name is required.");

        var workout = new Workout
        {
            UserId = userId,
            Name = name.Trim(),
            Date = date?.Date ?? DateTime.Today
        };

        _workouts.Insert(workout);
        return workout;
    }

    /// <summary>
    /// Adds an exercise to an existing workout.
    /// </summary>
    public bool AddExercise(int workoutId, int exerciseId, int reps, double weight)
    {
        var workout = _workouts.GetById(workoutId);
        if (workout is null) throw new ArgumentException($"Workout id {workoutId} not found.");

        var exercise = _exercises.GetById(exerciseId);
        if (exercise is null) throw new ArgumentException($"Exercise id {exerciseId} not found.");

        if (reps <= 0) throw new ArgumentException("Reps must be greater than 0.");
        if (weight < 0) throw new ArgumentException("Weight cannot be negative.");

        var workoutExercise = new WorkoutExercise
        {
            ExerciseId = exercise.Id,
            ExerciseName = exercise.Name,
            Reps = reps,
            Weight = weight
        };

        workout.Exercises.Add(workoutExercise);
        return _workouts.Update(workout);
    }

    /// <summary>
    /// Returns workouts for a user, newest first. Optional date range.
    /// </summary>
    public List<Workout> GetWorkouts(int userId, DateTime? from = null, DateTime? to = null)
    {
        var all = _workouts.GetByUserId(userId).ToList();

        if (from is not null) all = all.Where(w => w.Date >= from.Value.Date).ToList();
        if (to is not null) all = all.Where(w => w.Date < to.Value.Date.AddDays(1)).ToList();

        return all.OrderByDescending(w => w.Date).ToList();
    }

    /// <summary>
    /// Computes total volume for a workout (sum of reps * weight for all exercises).
    /// </summary>
    public static double ComputeVolume(Workout w) => w.Exercises.Sum(e => e.Reps * e.Weight);
}