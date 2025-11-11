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
}