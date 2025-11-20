using FitnessTracker.Models;

namespace FitnessTracker.Services;

/// <summary>
/// Simple in-memory session for the currently logged-in user.
/// </summary>
public static class AppSession
{
    public static User? CurrentUser { get; private set; }
    
    public static int CurrentUserId => CurrentUser?.Id ?? 0;
    
    public static void Login(User user) => CurrentUser = user;
    public static void Logout() => CurrentUser = null;
    
}