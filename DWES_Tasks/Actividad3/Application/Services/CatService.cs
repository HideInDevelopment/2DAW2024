using Actividad3.Application.Profiles;
using Actividad3.Common.Validators;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
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
        var result = storedCatItems.Select(CatMapper.MapEntityToDto);
        return result;
    }

    public async Task<IDto?> GetByIdAsync(Guid id)
    {
        var storedCat = await _repository.GetByIdAsync(id);
        return storedCat == null ? null : CatMapper.MapEntityToDto(storedCat);
    }

    public async Task AddAsync(IDto dto)
    {
        var carToPersist = CatMapper.MapDtoToEntity((CatDto)dto);
        if (_repository.GetAllAsync().Result.Any(cat => cat.Id == carToPersist.Id))
        {
            throw new EntityAlreadyExistException<Cat>(carToPersist);
        }
        await _repository.AddAsync(carToPersist);
    }

    public async Task UpdateAsync(IDto dto)
    {
        var catToUpdate = CatMapper.MapDtoToEntity((CatDto)dto);
        if (_repository.GetAllAsync().Result.Any(cat => cat.Id == catToUpdate.Id))
        {
            await _repository.UpdateAsync(catToUpdate);
        }
        else
        {
            throw new EntityNotFoundException<Cat>(catToUpdate);
        }
        
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}