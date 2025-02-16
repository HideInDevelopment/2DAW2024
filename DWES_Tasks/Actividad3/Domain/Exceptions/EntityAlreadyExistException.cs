namespace Actividad3.Domain.Exceptions;

public class EntityAlreadyExistException<TEntity> : Exception
{
    public EntityAlreadyExistException(TEntity entity) { }    
}