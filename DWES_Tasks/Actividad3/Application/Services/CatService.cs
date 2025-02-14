using Actividad3.Application.Profiles;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class CatService : ICatService
{
    private readonly ICatRepository _repository;
    public CatService(ICatRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IDto>> GetAllAsync()
    {
        var queryableCatItems = await _repository.GetAllAsync();
        var storedCatItems = queryableCatItems.ToList();
        var result = storedCatItems.Select(CatMapper.MapFromCatToDtoWithColony);
        return result;
    }

    public async Task<IDto?> GetByIdAsync(Guid id)
    {
        var storedCat = await _repository.GetByIdAsync(id);
        return storedCat == null ? null : CatMapper.MapFromCatToDtoWithColony(storedCat);
    }

    public Task<IDto?> AddAsync(IDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IDto?> UpdateAsync(IDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IDto?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}