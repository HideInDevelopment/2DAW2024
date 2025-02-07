using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class ColonyService : GenericService<Guid, Colony, ColonyDto>, IColonyService
{
    public ColonyService(IGenericRepository<Guid, Colony> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}