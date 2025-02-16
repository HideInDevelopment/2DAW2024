namespace Actividad3.Presentation.Dtos;

public interface IMapToEntity<TEntity> where TEntity : class
{
    TEntity ToEntity();
}