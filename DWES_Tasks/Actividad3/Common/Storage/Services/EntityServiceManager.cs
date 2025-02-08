using System.Text.Json;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Services;

public class EntityServiceManager<TKey, TEntity> where TEntity : Entity<TKey>
{
    private IEnumerable<TEntity> _entityItems;

    public EntityServiceManager(IEnumerable<TEntity> entityItems)
    {
        _entityItems = entityItems;
    }

    public IReadOnlyList<TEntity>? FillWithItems(string entityPath)
    {
        var jsonItems = File.ReadAllText(entityPath);
        return JsonSerializer.Deserialize<IReadOnlyList<TEntity>>(jsonItems);
    }

    public bool CompareEntityKeys(TKey leftEntityKey, TKey rightEntityKey) =>
        EqualityComparer<TKey>.Default.Equals(leftEntityKey, rightEntityKey);

    public TEntity? UpdateEntity(TEntity entity, IEnumerable<TEntity> entityItems)
    {
        var entityToUpdate = entityItems.ToList().Find(e => CompareEntityKeys(e.Id, entity.Id));
        if (entityToUpdate == null)
        {
            return null;
        }

        foreach (var propertyItem in entityToUpdate.GetType().GetProperties())
        {
            if(propertyItem.CanWrite)
                propertyItem.SetValue(entityToUpdate, propertyItem.GetValue(entity));
        }
        
        return entityToUpdate;
    } 
    
    public void SaveEntity(string entityPath, IEnumerable<TEntity> entityItems)
    {
        var jsonEntityItems = JsonSerializer.Serialize(entityItems);
        File.WriteAllText(entityPath, jsonEntityItems);
    }
}