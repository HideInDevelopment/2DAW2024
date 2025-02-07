using Actvidad3.Domain.Entities;
using Actvidad3.Presentation.Dtos;

namespace Actvidad3.Domain.Services;

public interface IColonyService : IGenericService<Guid, Colony, ColonyDto>
{
    
}