namespace Actividad3.Domain.Exceptions;

public class EntityNotFoundException<TEntity> : Exception
{
    public EntityNotFoundException(TEntity? entity) { }    
}