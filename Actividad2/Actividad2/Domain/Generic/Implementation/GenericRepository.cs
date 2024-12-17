using System.Linq.Expressions;
using Actividad2.Domain.Generic.Interface;
using Actividad2.Domain.Generic.Model;
using Actividad2.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Actividad2.Domain.Generic.Implementation;

public class GenericRepository<TKey, TEntity>(DatabaseContext databaseContext) : IGenericRepository<TKey, TEntity>
    where TEntity : Entity<TKey>
{
    private readonly DbSet<TEntity> _entitySet = databaseContext.Set<TEntity>();

    public TEntity? GetById(TKey id) => _entitySet.Find(id);

    public IEnumerable<TEntity>? GetByIds(IEnumerable<TKey> ids) =>
        GetAll().Where(x => ids.Contains(x.Id)).ToList();

    public IQueryable<TEntity> GetAll() => _entitySet;

    public TEntity Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var addedEntity = databaseContext.Set<TEntity>().Add(entity).Entity;
        return addedEntity;
    }

    public IEnumerable<TEntity>? Add(IEnumerable<TEntity> entities)
    {
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        if (enumerable.Any(x => false))
        {
            throw new ArgumentException(
                "One or more entities in the collection appears to be null."
            );
        }

        if (enumerable.Length == 0) return null;
        databaseContext.Set<TEntity>().AddRange(enumerable);
        return enumerable;

    }

    public TEntity Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var updatedEntity = databaseContext.Set<TEntity>().Update(entity).Entity;
        return updatedEntity;
    }

    public IEnumerable<TEntity>? Update(IEnumerable<TEntity> entities)
    {
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        if (enumerable.Length == 0) return null;
        databaseContext.Set<TEntity>().UpdateRange(enumerable);
        return enumerable;

    }

    public TEntity? Delete(TKey id)
    {
        if (id is null)
            throw new ArgumentException("The id is null.");

        var entity = GetById(id);
        if (entity == null)
            return null;
        var deletedEntity = _entitySet.Remove(entity).Entity;
        return deletedEntity;
    }

    public IEnumerable<TEntity>? Delete(IEnumerable<TKey> ids)
    {
        var entities = GetByIds(ids);
        if (entities != null)
        {
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            _entitySet.RemoveRange(enumerable);
            return enumerable;
        }
        else
            return null;
    }

    //Custom functions
    public IQueryable<TEntity> Where(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null
    ) =>
        include?.Invoke(databaseContext.Set<TEntity>().Where(predicate))
        ?? databaseContext.Set<TEntity>().Where(predicate);
}