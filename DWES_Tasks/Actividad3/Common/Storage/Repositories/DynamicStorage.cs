using Actvidad3.Common.Functions;
using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Repositories;

public class DynamicStorage
{
    private readonly string _catPath = GenericFunctions.GetSpecificPath("Database", "CatDB");
    private readonly string _colonyPath = GenericFunctions.GetSpecificPath("Database", "ColonyDB");
    private readonly string _partnerPath = GenericFunctions.GetSpecificPath("Database", "PartnerDB");
    private readonly string _colonyPartnerPath = GenericFunctions.GetSpecificPath("Database", "ColonyPartnerDB");
    
    private IEnumerable<Cat> _storedCatItems;
    private IEnumerable<Colony> _storedColonyItems;
    private IEnumerable<Partner> _storedPartnerItems;
    private IEnumerable<ColonyPartner> _storedColonyPartnerItems;
    
    private readonly ManageEntityService<Cat> _catManager;
    private readonly ManageEntityService<Colony> _colonyManager;
    private readonly ManageEntityService<Partner> _partnerManager;
    private readonly ManageEntityService<ColonyPartner> _colonyPartnerManager;
    
    private readonly CatRepository _catRepository;
    private readonly ColonyRepository _colonyRepository;
    private readonly PartnerRepository _partnerRepository;
    private readonly ColonyPartnerRepository _colonyPartnerRepository;

    public DynamicStorage(ManageEntityService<Cat> catManager,
        ManageEntityService<Colony> colonyManager,
        ManageEntityService<Partner> partnerManager,
        ManageEntityService<ColonyPartner> colonyPartnerManager)
    {
        _catManager = catManager;
        _colonyManager = colonyManager;
        _partnerManager = partnerManager;
        _colonyPartnerManager = colonyPartnerManager;
        
        _storedCatItems = _catManager.FillWithItems(_catPath) ??  Array.Empty<Cat>();
        _storedColonyItems = _colonyManager.FillWithItems(_colonyPath) ??  Array.Empty<Colony>();
        _storedPartnerItems = _partnerManager.FillWithItems(_partnerPath) ??  Array.Empty<Partner>();
        _storedColonyPartnerItems = _colonyPartnerManager.FillWithItems(_colonyPartnerPath) ??  Array.Empty<ColonyPartner>();

        _catRepository = new CatRepository(_storedCatItems, _catManager);
        _colonyRepository = new ColonyRepository(_storedColonyItems, _colonyManager);
        _partnerRepository = new PartnerRepository(_storedPartnerItems, _partnerManager);
        _colonyPartnerRepository = new ColonyPartnerRepository(_storedColonyPartnerItems, _colonyPartnerManager);
    }
}