using FitnessTracker.Core;
using FitnessTracker.Core.Repositories;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

/// <summary>
/// This class is responsible for authenticating users. Registering and logging in.
/// </summary>
public class AuthService
{
    private readonly UserRepository _users;
    public AuthService(Db db) => _users = db.Users;
    
    /// <summary>
    /// Method for registering a new user.
    /// </summary>
    public User Register(string name, string username, string password)
    {
        if(string.IsNullOrEmpty(name)) throw new ArgumentException("Name is required");
        if(string.IsNullOrEmpty(username)) throw new ArgumentException("Username is required");
        if(string.IsNullOrEmpty(password)) throw new ArgumentException("Password is required");
        if(_users.GetByUsername(username) != null) throw new ArgumentException("Username is already taken");

        var user = new User 
        { 
            Name = name.Trim(), 
            Username = username.Trim(), 
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password) 
        };
        
        _users.Insert(user);
        return user;
    }

    /// <summary>
    /// Login for a user. Returns null if the username or password is incorrect.
    /// </summary>
    public User? Login(string username, string password)
    {
        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;

        var user = _users.GetByUsername(username.Trim());

        if (user == null) return null;
        
        return !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? null : user;
    }
}