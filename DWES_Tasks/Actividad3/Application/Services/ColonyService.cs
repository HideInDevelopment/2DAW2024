using Actividad3.Application.Profiles;
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
    private readonly ICatRepository _catRepository;
    private readonly IColonyPartnerRepository _colonyPartnerRepository;
    private readonly IPartnerRepository _partnerRepository;
    public ColonyService(IColonyRepository repository, ICatRepository catRepository, IColonyPartnerRepository colonyPartnerRepository, IPartnerRepository partnerRepository)
    {
        _repository = repository;
        _catRepository = catRepository;
        _colonyPartnerRepository = colonyPartnerRepository;
        _partnerRepository = partnerRepository;
    }

    public async Task<IEnumerable<IDto>> GetAllAsync()
    {
        var queryableColonyItems = await _repository.GetAllAsync();
        var storedColonyItems = queryableColonyItems.Select(colonyItem => colonyItem.ToDto()).ToList();
        
        var queryableCatItems = await _catRepository.GetAllAsync();
        var storedCatItems = queryableCatItems.Select(catItem => catItem.ToDto()).ToList();
        
        var queryableColonyPartnerItems = await _colonyPartnerRepository.GetAllAsync();
        var storedColonyPartnerItems = queryableColonyPartnerItems.Select(colonyPartnerItem => colonyPartnerItem.ToDto()).ToList();
        
        var queryablePartnerItems = await _partnerRepository.GetAllAsync();
        var storedPartnerItems = queryablePartnerItems.Select(partnerItem => partnerItem.ToDto()).ToList();
        
        storedColonyItems.ForEach(colonyItem =>
        {
            colonyItem.CatItems = storedCatItems.Where(x => x.ColonyId == colonyItem.Id).ToList();
            colonyItem.PartnerItems = storedPartnerItems
                .Where(partnerItem => storedColonyPartnerItems
                    .Where(x => x.ColonyId == colonyItem.Id)
                    .Select(colonyPartnerItem => colonyPartnerItem.PartnerId)
                    .Contains(partnerItem.Id))
                .ToList();
        });
        
        return storedColonyItems;
    }

    public Task<IDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(IDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}