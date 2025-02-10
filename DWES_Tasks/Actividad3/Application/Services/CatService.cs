using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class CatService : GenericService<Guid, Cat, CatDto>, ICatService
{
    public CatService(IGenericRepository<Guid, Cat> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}