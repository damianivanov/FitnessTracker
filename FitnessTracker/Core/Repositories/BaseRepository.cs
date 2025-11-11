using System.Linq.Expressions;
using FitnessTracker.Core.Interfaces;
using FitnessTracker.Models;
using LiteDB;

namespace FitnessTracker.Core.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly LiteDatabase _db;
    protected readonly ILiteCollection<T> _collection;

    protected BaseRepository(LiteDatabase db, string collectionName)
    {
        _db = db;
        _collection = _db.GetCollection<T>(collectionName);
        _collection.EnsureIndex(x => x.Id, unique: true);
    }
    public virtual IEnumerable<T> GetAll() => _collection.FindAll();

    public virtual T? GetById(int id) => _collection.FindById(id);

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _collection.Find(predicate);
    
    public virtual int Insert(T entity)
    {
        entity.MarkUpdated();
        return _collection.Insert(entity);
    }

    public virtual bool Update(T entity)
    {
        entity.MarkUpdated();
        return _collection.Update(entity);
    }

    public virtual bool Delete(int id) => _collection.Delete(id);
}