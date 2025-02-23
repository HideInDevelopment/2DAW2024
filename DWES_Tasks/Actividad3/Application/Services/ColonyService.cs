using Actividad3.Application.Profiles;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
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

    public async Task<IEnumerable<IDto>> GetAllAsync(){
        var (colonies, cats, colonyPartners, partners) = await GetAllDataAsync();
        return BuildDataResponse(colonies, cats, colonyPartners, partners).ToList();
    }

    public async Task<IDto?> GetByIdAsync(Guid id)
    {
        var (colonies, cats, colonyPartners, partners) = await GetAllDataAsync();
        return BuildDataResponse(colonies, cats, colonyPartners, partners).FirstOrDefault(colony => colony.Id == id);
    }

    public async Task AddAsync(IDto dto)
    {
        var colonyToPersist = ColonyMapper.MapDtoToEntity((ColonyDto)dto);
        var existingColonyItems = await _repository.GetAllAsync();
        if (existingColonyItems.Any(colony => colony.Id == colonyToPersist.Id))
        {
            throw new EntityAlreadyExistException<Colony>(colonyToPersist);
        }
        await PerformAsyncOperation((ColonyDto)dto, colonyToPersist);
        await _repository.AddAsync(colonyToPersist);
    }

    public async Task UpdateAsync(IDto dto)
    {
        var colonyToUpdate = ColonyMapper.MapDtoToEntity((ColonyDto)dto);
        var existingColonyItems = await _repository.GetAllAsync();
        if (existingColonyItems.Any(colony => colony.Id == colonyToUpdate.Id))
        {
            await PerformAsyncOperation((ColonyDto)dto, colonyToUpdate);
            await _repository.UpdateAsync(colonyToUpdate);
        }
        else
        {
            throw new EntityNotFoundException<Colony>(colonyToUpdate);
        }
    }

    private async Task PerformAsyncOperation(ColonyDto colony, Colony colonyToUpdate)
    {
        if (colony.PartnerItems.Count != 0)
        {
            var partnerItemsId = colony.PartnerItems.Select(partnerItem => partnerItem.Id).ToList();
            var colonyPartnerItems = (await _colonyPartnerRepository.GetAllAsync()).ToList();
            var notExistingPartnerItems = partnerItemsId.Except(colonyPartnerItems.Select(item => item.PartnerId)).ToList();

            foreach (var colonyPartnerItemToStore in notExistingPartnerItems
                         .Select(notExistingPartnerItem => new ColonyPartner()
                     {
                         ColonyId = colony.Id,
                         PartnerId = notExistingPartnerItem
                     }))
            {
                await _colonyPartnerRepository.AddAsync(colonyPartnerItemToStore);
            }
        }
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    
    private IEnumerable<ColonyDto> BuildDataResponse(List<Colony> colonies, List<Cat> cats, List<ColonyPartner> colonyPartners, List<Partner> partners)
    {
        return colonies.Select(colony =>
        {
            var colonyDto = colony.ToDto();

            colonyDto.CatItems = cats
                .Where(cat => cat.ColonyId == colony.Id)
                .Select(cat => cat.ToDto())
                .ToList();

            var colonyPartnerIds = colonyPartners
                .Where(cp => cp.ColonyId == colony.Id)
                .Select(cp => cp.PartnerId)
                .ToHashSet();

            colonyDto.PartnerItems = partners
                .Where(partner => colonyPartnerIds.Contains(partner.Id))
                .Select(partner => partner.ToDto())
                .ToList();

            return colonyDto;
        });
    }
    
    private async Task<(List<Colony>, List<Cat>, List<ColonyPartner>, List<Partner>)> GetAllDataAsync()
    {
        var coloniesTask = _repository.GetAllAsync();
        var catsTask = _catRepository.GetAllAsync();
        var colonyPartnersTask = _colonyPartnerRepository.GetAllAsync();
        var partnersTask = _partnerRepository.GetAllAsync();

        await Task.WhenAll(coloniesTask, catsTask, colonyPartnersTask, partnersTask);

        return (coloniesTask.Result.ToList(), 
            catsTask.Result.ToList(), 
            colonyPartnersTask.Result.ToList(), 
            partnersTask.Result.ToList());
    }
}