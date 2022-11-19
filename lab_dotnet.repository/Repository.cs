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

    public bool Delete(T obj)
    {
        try
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex.ToString());
            return false;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
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

    public T Save(T obj)
    {
        try
        {
            if (obj.IsNew())
            {
                obj.Init();
                var result = _context.Set<T>().Add(obj);
                _context.SaveChanges();
                return result.Entity;
            }
            else
            {
                obj.ModificationTime = DateTime.UtcNow;
                var result = _context.Set<T>().Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return result.Entity;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }
}