using lab_dotnet.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace lab_dotnet.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private DbContext _context;
    private ILogger<Repository<T>> logger;

    public Repository(DbContext context, ILogger<Repository<T>> logger)
    {
        _context = context;
        this.logger = logger;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    private T Insert(T obj)
    {
        try
        {
            obj.Init();
            var result = _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return result.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    private T Update(T obj)
    {
        try
        {
            obj.ModificationTime = DateTime.UtcNow;
            var result = _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return result.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    public T Save(T obj)
    {
        if (obj.IsNew())
        {
            return Insert(obj);
        }
        else
        {
            return Update(obj);
        }
    }

    public void Delete(T obj)
    {
        try
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }
}