namespace Actividad2.Domain.Generic.Interface;

public interface IEntityService<in TKey, TEntity>
{
    ICollection<TEntity>? Get();
    TEntity? Get(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity);
    TEntity? Delete(TKey id);
}