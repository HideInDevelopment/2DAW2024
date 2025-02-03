namespace Actividad2.Domain.Generic.Interface;

public interface IEntityRepository<in TKey, TEntity>
{
    IQueryable<TEntity> Get();
    TEntity? Get(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity);
    TEntity? Delete(TKey id);
}