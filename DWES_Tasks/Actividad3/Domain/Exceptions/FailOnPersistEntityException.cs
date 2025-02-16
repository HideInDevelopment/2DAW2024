namespace Actividad3.Domain.Exceptions;

public class FailOnPersistEntityException<TEntity> : Exception
{
    public FailOnPersistEntityException(TEntity entity){}
}