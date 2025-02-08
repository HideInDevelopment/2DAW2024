using Actvidad3.Common.Storage.Services;
using Actvidad3.Common.Validators;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;

namespace Actvidad3.Common.Storage.Repositories;

public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity> where TEntity : Entity<TKey>
{
    private readonly string _filePath;
    private readonly IReadOnlyList<TEntity> _storedItems;
    private readonly ManageEntityService<TKey, TEntity> _entityManager;

    public GenericRepository(string filePath, IReadOnlyList<TEntity> storedItems,
        ManageEntityService<TKey, TEntity> entityManager)
    {
        _filePath = filePath;
        _storedItems = storedItems;
        _entityManager = entityManager;
    }
    public Task<IReadOnlyList<TEntity>> GetAllAsync() 
        => ListValidator.IsNullOrEmpty(_storedItems) 
        ? Task.FromResult<IReadOnlyList<TEntity>>(new List<TEntity>()) 
        : Task.FromResult(_storedItems);

    public Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = _storedItems.ToList().Find(x => _entityManager.CompareEntityKeys(x.Id, id));
        return EntityValidator.IsNullOrDefault(entity) ? Task.FromResult<TEntity?>(null) : Task.FromResult(entity);
    }

    public Task<TEntity?> AddAsync(TEntity entity)
    {
        _storedItems.ToList().Add(entity);
        _entityManager.SaveEntity(_filePath, _storedItems);
        return Task.FromResult<TEntity?>(entity);
    }

    public Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _entityManager.UpdateEntity(entity, _storedItems);
        return Task.FromResult<TEntity?>(entity);
    }

    public Task<TEntity?> DeleteAsync(TEntity entity)
    {
        _storedItems.ToList().Remove(entity);
        return Task.FromResult<TEntity?>(entity);
    }
}