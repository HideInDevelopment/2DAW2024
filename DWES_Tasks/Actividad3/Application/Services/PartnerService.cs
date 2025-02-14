using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class PartnerService : IPartnerService
{
    private readonly IPartnerRepository _repository;
    public PartnerService(IPartnerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<PartnerDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PartnerDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PartnerDto?> AddAsync(PartnerDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<PartnerDto?> UpdateAsync(PartnerDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<PartnerDto?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}