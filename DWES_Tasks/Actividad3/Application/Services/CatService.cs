using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class CatService : GenericService<Guid, Cat, CatDto>, ICatService
{
    public CatService(IGenericRepository<Guid, Cat> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}