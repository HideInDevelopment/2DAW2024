using Actividad3.Domain.Entities;

namespace Actividad3.Domain.Repositories.Contracts;

public interface ICatRepository : IGenericRepository<Guid, Cat>
{
    
}