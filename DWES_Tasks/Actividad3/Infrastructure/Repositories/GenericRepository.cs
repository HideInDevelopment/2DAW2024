using Actividad3.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Actividad3.Domain.Repositories;

public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity>
    where TEntity : class
{
    private readonly DatabaseContext _context;
    private readonly DbSet<TEntity> _entity;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _entity = context.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _entity.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await _entity.FindAsync(id) ?? null;
    }

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0 ? entity : null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _entity.Update(entity);
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0 ? entity : null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    public async Task<TEntity?> DeleteAsync(TKey key)
    {
        var entity = await _entity.FindAsync(key);
        if (entity is null) return null;
        _entity.Remove(entity);
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0 ? entity : null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}