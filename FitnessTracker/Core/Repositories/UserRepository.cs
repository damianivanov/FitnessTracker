using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class UserRepository: BaseRepository<User>
{
    public UserRepository(LiteDatabase db) : base(db, "Users")
    {
        _collection.EnsureIndex(u => u.Username, unique: true);
    }
    
    public User? GetByUsername(string username) => _collection.FindOne(u => u.Username == username);
}