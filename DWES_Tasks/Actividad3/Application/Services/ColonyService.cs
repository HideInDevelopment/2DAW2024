using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class ColonyService : GenericService<Guid, ColonyDto, Colony>, IColonyService
{
    public ColonyService(IGenericRepository<Guid, ColonyDto> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}