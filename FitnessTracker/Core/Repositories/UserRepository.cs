// Дамян Николаев Иванов - ФН: F123976
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

// Repository that manages user accounts
public class UserRepository: BaseRepository<User>
{
    public UserRepository(LiteDatabase db) : base(db, "Users")
    {
        // Usernames must be unique
        _collection.EnsureIndex(u => u.Username, unique: true);
    }
    
    /// <summary>
    /// Finds a user by their username (used for login)
    /// </summary>
    public User? GetByUsername(string username) => _collection.FindOne(u => u.Username == username);
}