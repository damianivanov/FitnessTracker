using System.Linq.Expressions;
using FitnessTracker.Models;

namespace FitnessTracker.Core.Interfaces;

/// <summary>
/// Generic repository interface defining standard CRUD operations for all entities
/// </summary>
/// <typeparam name="T">Entity type that inherits from BaseEntity</typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Retrieves all entities from the collection
    /// </summary>
    IEnumerable<T> GetAll();
    
    /// <summary>
    /// Retrieves a single entity by its ID
    /// </summary>
    T? GetById(int id);
    
    /// <summary>
    /// Finds entities matching a predicate/filter expression
    /// </summary>
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Inserts a new entity and returns the generated ID
    /// </summary>
    int Insert(T entity);
    
    /// <summary>
    /// Updates an existing entity and returns success status
    /// </summary>
    bool Update(T entity);
    
    /// <summary>
    /// Deletes an entity by ID and returns success status
    /// </summary>
    bool Delete(int id);
}