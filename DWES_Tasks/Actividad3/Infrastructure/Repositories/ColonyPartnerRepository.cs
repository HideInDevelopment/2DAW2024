using Actvidad3.Domain.Entities;
using Actvidad3.Infrastructure.Persistence;

namespace Actvidad3.Domain.Repositories;

public class ColonyPartnerRepository(DatabaseContext context)
    : GenericRepository<Guid, ColonyPartner>(context), IColonyPartnerRepository;