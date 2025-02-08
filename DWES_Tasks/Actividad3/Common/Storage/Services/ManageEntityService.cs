using System.Text.Json;
using Actvidad3.Domain.Contracts;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Services;

public class ManageEntityService<TEntity> where TEntity : class, IEntity
{
    private IEnumerable<TEntity> _entityItems;

    public ManageEntityService(IEnumerable<TEntity> entityItems)
    {
        _entityItems = entityItems;
    }

    public IEnumerable<TEntity>? FillWithItems(string entityPath)
    {
        var jsonItems = File.ReadAllText(entityPath);
        return JsonSerializer.Deserialize<IEnumerable<TEntity>>(jsonItems);
    }

    private TEntity? UpdateEntity(TEntity entity, IEnumerable<TEntity> entityItems)
    {
        var entityToUpdate = entityItems.ToList().Find(e => e.Id == entity.Id);
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
}