using System.Linq.Expressions;
using FitnessTracker.Models;

namespace FitnessTracker.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    int Insert(T entity);
    bool Update(T entity);
    bool Delete(int id);
}