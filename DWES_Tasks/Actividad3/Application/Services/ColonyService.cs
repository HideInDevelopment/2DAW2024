using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class ColonyService : IColonyService
{
    private readonly IColonyRepository _repository;
    public ColonyService(IColonyRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ColonyDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ColonyDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ColonyDto?> AddAsync(ColonyDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ColonyDto?> UpdateAsync(ColonyDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ColonyDto?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}