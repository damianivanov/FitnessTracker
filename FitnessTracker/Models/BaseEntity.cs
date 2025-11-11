namespace FitnessTracker.Models;
using LiteDB;
public class BaseEntity
{
    [BsonId] public int Id { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
    
    public void MarkUpdated() => DateModified = DateTime.UtcNow;
}