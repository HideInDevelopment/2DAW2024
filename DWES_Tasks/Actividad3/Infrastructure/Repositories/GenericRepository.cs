using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
using Actividad3.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Actividad3.Domain.Repositories;

public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity>
    where TEntity : Entity<TKey>
{
    private readonly DatabaseContext _context;
    private readonly DbSet<TEntity> _entity;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _entity = context.Set<TEntity>();
    }

    public Task<IQueryable<TEntity>> GetAllAsync()
    {
        IQueryable<TEntity> query = _entity.AsSplitQuery();

        return Task.FromResult(query);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entityItems = await GetAllAsync();
        return entityItems.FirstOrDefault(x => x.Id != null && x.Id.Equals(id)) ?? null;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new FailOnPersistEntityException<TEntity>(entity);
        }
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _entity.Update(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new FailOnPersistEntityException<TEntity>(entity);
        }
    }
    
    public async Task DeleteAsync(TKey key)
    {
        var entity = await _entity.FindAsync(key);
        if (entity is null) throw new EntityNotFoundException<TEntity>(entity);
        _entity.Remove(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new FailOnPersistEntityException<TEntity>(entity);
        }
    }
}