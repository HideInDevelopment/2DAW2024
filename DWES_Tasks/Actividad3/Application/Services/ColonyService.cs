using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class ColonyService : GenericService<Guid, Colony, ColonyDto>, IColonyService
{
    public ColonyService(IGenericRepository<Guid, Colony> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}