// Дамян Николаев Иванов - ФН: F123976
namespace FitnessTracker.Models;

/// <summary>
/// Represents a user account in the fitness tracking system
/// </summary>
public class User: BaseEntity
{
    /// <summary>
    /// Display name of the user (full name)
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Unique username for login
    /// </summary>
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    /// BCrypt hashed password for secure authentication
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;
}