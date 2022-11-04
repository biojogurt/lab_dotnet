using System.Linq.Expressions;
using lab_dotnet.entity.Models;

namespace lab_dotnet.repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetById(Guid id);
    T Save(T obj);
    bool Delete(T obj);
}