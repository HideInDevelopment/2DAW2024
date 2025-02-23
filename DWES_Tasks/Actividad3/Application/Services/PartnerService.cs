using Actividad3.Application.Profiles;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
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

    public async Task<IEnumerable<IDto>> GetAllAsync() => 
        (await _repository.GetAllAsync()).Select(partner => partner.ToDto());

    public async Task<IDto?> GetByIdAsync(Guid id) =>
    (await _repository.GetByIdAsync(id))?.ToDto();

    public async Task AddAsync(IDto dto)
    {
        var partnerToPersist = PartnerMapper.MapDtoToEntity((PartnerDto)dto);
        if (_repository.GetAllAsync().Result.Any(partner => partner.Id == partnerToPersist.Id))
        {
            throw new EntityAlreadyExistException<Partner>(partnerToPersist);
        }
        await _repository.AddAsync(partnerToPersist);
    }

    public async Task UpdateAsync(IDto dto)
    {
        var partnerToUpdate = PartnerMapper.MapDtoToEntity((PartnerDto)dto);
        if (_repository.GetAllAsync().Result.Any(partner => partner.Id == partnerToUpdate.Id))
        {
            await _repository.UpdateAsync(partnerToUpdate);
        }
        else
        {
            throw new EntityNotFoundException<Partner>(partnerToUpdate);
        }
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}