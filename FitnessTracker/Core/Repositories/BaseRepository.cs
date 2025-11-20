using System.Linq.Expressions;
// Дамян Николаев Иванов - ФН: F123976
using FitnessTracker.Core.Interfaces;
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

/// <summary>
/// Base repository implementation providing common CRUD operations for all entity types
/// </summary>
/// <typeparam name="T">Entity type that inherits from BaseEntity</typeparam>
public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly LiteDatabase _db;
    protected readonly ILiteCollection<T> _collection;

    /// <summary>
    /// Initializes the repository with a database connection and collection name
    /// </summary>
    /// <param name="db">LiteDB database instance</param>
    /// <param name="collectionName">Name of the collection/table</param>
    protected BaseRepository(LiteDatabase db, string collectionName)
    {
        _db = db;
        _collection = _db.GetCollection<T>(collectionName);
        // Ensure unique index on Id field
        _collection.EnsureIndex(x => x.Id, unique: true);
    }
    
    /// <summary>
    /// Gets all entities in the collection
    /// </summary>
    public virtual IEnumerable<T> GetAll() => _collection.FindAll();

    /// <summary>
    /// Gets an entity by its ID
    /// </summary>
    public virtual T? GetById(int id) => _collection.FindById(id);

    /// <summary>
    /// Finds entities matching the given predicate
    /// </summary>
    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _collection.Find(predicate);
    
    /// <summary>
    /// Inserts a new entity and updates its timestamp
    /// </summary>
    public virtual int Insert(T entity)
    {
        entity.MarkUpdated();
        return _collection.Insert(entity);
    }

    /// <summary>
    /// Updates an existing entity and refreshes its timestamp
    /// </summary>
    public virtual bool Update(T entity)
    {
        entity.MarkUpdated();
        return _collection.Update(entity);
    }

    /// <summary>
    /// Deletes an entity by its ID
    /// </summary>
    public virtual bool Delete(int id) => _collection.Delete(id);
}