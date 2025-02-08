using Actvidad3.Common.Storage.Repositories;
using Actvidad3.Common.Validators;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class CatService : GenericService<Guid, Cat, CatDto>, ICatService
{
    private readonly DynamicStorage _storage;
    private readonly IMapper _mapper;
    public CatService(IGenericRepository<Guid, Cat> repository, IMapper mapper, DynamicStorage storage) : base(repository, mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CatDto>?> GetStoredCatItems()
    {
        var items = await _storage.GetStoredCatItems();
        return ListValidator.IsNullOrEmpty(items) ? null : _mapper.Map<IReadOnlyList<CatDto>>(items);
    }
}