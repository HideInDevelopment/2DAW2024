using Actvidad3.Common.Functions;
using Actvidad3.Common.Storage.Factories;
using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Repositories;

public class DynamicStorage
{
    private readonly string _catPath = GenericFunctions.GetSpecificPath("Database", "CatDB") ?? "";
    private readonly string _colonyPath = GenericFunctions.GetSpecificPath("Database", "ColonyDB") ?? "";
    private readonly string _partnerPath = GenericFunctions.GetSpecificPath("Database", "PartnerDB") ?? "";
    private readonly string _colonyPartnerPath = GenericFunctions.GetSpecificPath("Database", "ColonyPartnerDB") ?? "";
    
    private readonly IReadOnlyList<Cat> _storedCatItems;
    private readonly IReadOnlyList<Colony> _storedColonyItems;
    private readonly IReadOnlyList<Partner> _storedPartnerItems;
    private readonly IReadOnlyList<ColonyPartner> _storedColonyPartnerItems;
    
    private readonly IStorageRepositoryFactory _storageFactory;
    
    private readonly EntityServiceManager<Guid, Cat> _catManager;
    private readonly EntityServiceManager<Guid, Colony> _colonyManager;
    private readonly EntityServiceManager<Guid, Partner> _partnerManager;
    private readonly EntityServiceManager<Guid, ColonyPartner> _colonyPartnerManager;
    
    private StorageCatRepository StorageCatRepository { get; }
    private StorageColonyRepository StorageColonyRepository { get; }
    private StoragePartnerRepository StoragePartnerRepository { get; }
    private StorageColonyPartnerRepository StorageColonyPartnerRepository { get; }

    public DynamicStorage(IStorageRepositoryFactory storageFactory,
        EntityServiceManager<Guid,Cat> catManager,
        EntityServiceManager<Guid, Colony> colonyManager,
        EntityServiceManager<Guid, Partner> partnerManager,
        EntityServiceManager<Guid, ColonyPartner> colonyPartnerManager)
    {
        _storageFactory = storageFactory;
        _catManager = catManager;
        _colonyManager = colonyManager;
        _partnerManager = partnerManager;
        _colonyPartnerManager = colonyPartnerManager;
        
        _storedCatItems = _catManager.FillWithItems(_catPath) ??  Array.Empty<Cat>();
        _storedColonyItems = _colonyManager.FillWithItems(_colonyPath) ??  Array.Empty<Colony>();
        _storedPartnerItems = _partnerManager.FillWithItems(_partnerPath) ??  Array.Empty<Partner>();
        _storedColonyPartnerItems = _colonyPartnerManager.FillWithItems(_colonyPartnerPath) ??  Array.Empty<ColonyPartner>();

        StorageCatRepository = _storageFactory.CreateCatRepository(_catPath, _storedCatItems, _catManager);
        StorageColonyRepository = _storageFactory.CreateColonyRepository(_colonyPath, _storedColonyItems, _colonyManager);
        StoragePartnerRepository = _storageFactory.CreatePartnerRepository(_partnerPath, _storedPartnerItems, _partnerManager);
        StorageColonyPartnerRepository = _storageFactory.CreateColonyPartnerRepository(_colonyPartnerPath, _storedColonyPartnerItems, _colonyPartnerManager);
    }
    
    // Cat zone
    public async Task<IReadOnlyList<Cat>> GetStoredCatItems() => await Task.FromResult(_storedCatItems);
    public async Task<Cat?> GetStoredCatById(Guid id) => await Task.FromResult(_storedCatItems.FirstOrDefault(x => x.Id == id));
    public async Task<Cat?> SaveCatInStore(Cat cat) => await StorageCatRepository.AddAsync(cat);
    public async Task<Cat?> UpdateCatInStore(Cat cat) => await StorageCatRepository.UpdateAsync(cat);
    public async Task<Cat?> DeleteCatFromStore(Guid id) => await StorageCatRepository.DeleteAsync(id);

    // Colony zone
    public async Task<IReadOnlyList<Colony>> GetIncompleteStoredColonyItems() => await Task.FromResult(_storedColonyItems);
    public async Task<IReadOnlyList<Colony>> GetCompleteStoredColonyItems()
    {
        var catItems = await GetStoredCatItems();
        var colonyPartnerItems = await GetCompleteColonyPartnerItems();
        
        foreach (var colony in _storedColonyItems)
        {
            // Obtaining catItems from this colony
            colony.CatItems = catItems.Where(c => c.ColonyId == colony.Id) as IReadOnlyList<Cat>;
            
            // Obtaining colonyPartnerItems from this colony
            colony.ColonyPartnerItems = colonyPartnerItems.Where(c => c.ColonyId == colony.Id) as IReadOnlyList<ColonyPartner>;
        }
        return await Task.FromResult(_storedColonyItems);
    }

    // Partner zone
    public async Task<IReadOnlyList<Partner>> GetIncompleteStoredPartnerItems() => await Task.FromResult(_storedPartnerItems);
    
    public async Task<IReadOnlyList<Partner>> GetCompleteStoredPartnerItems()
    {
        var colonyPartnerItems = await GetCompleteColonyPartnerItems();
        
        foreach (var partner in _storedPartnerItems)
        {
            // Obtaining colonyPartnerItems from this colony
            partner.ColonyPartnerItems = colonyPartnerItems.Where(c => c.PartnerId == partner.Id) as IReadOnlyList<ColonyPartner>;
        }
        return await Task.FromResult(_storedPartnerItems);
    }
    
    //ColonyPartner zone
    public async Task<IReadOnlyList<ColonyPartner>> GetCompleteColonyPartnerItems()
    {
        var colonyItems = await GetIncompleteStoredColonyItems();
        var partnerItems = await GetCompleteStoredColonyItems();
        
        foreach (var colonyPartner in _storedColonyPartnerItems)
        {
            colonyPartner.Colony = colonyItems.FirstOrDefault(c => c.Id == colonyPartner.ColonyId);
            colonyPartner.Colony = partnerItems.FirstOrDefault(p => p.Id == colonyPartner.PartnerId);
        }

        return await Task.FromResult(_storedColonyPartnerItems);
    }
}