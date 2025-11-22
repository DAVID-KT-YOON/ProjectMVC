using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T>:IRepository<T> where T:class
{
    protected readonly MovieShopDbContext _context;
    public BaseRepository(MovieShopDbContext context)
    {
        _context = context;
        
    }
    public T Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public T DeleteById(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        return null;

    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
}