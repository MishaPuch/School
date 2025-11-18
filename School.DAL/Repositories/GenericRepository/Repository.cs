using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace School.DAL.Repositories.GenericRepository;

public class Repository<T> where T : class
{
    protected readonly SchoolDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(SchoolDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, ct);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbSet.ToListAsync(ct);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(ct);
    }

    public virtual async Task<Guid> AddAsync(T entity, CancellationToken ct = default)
    {
        var entry = await _dbSet.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);

        var idProperty = entry.Entity.GetType().GetProperty("Id")
            ?? throw new InvalidOperationException("Entity doesn't have a property named 'Id'");

        return (Guid)idProperty.GetValue(entry.Entity)!;
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
}
