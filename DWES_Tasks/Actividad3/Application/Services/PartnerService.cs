using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class PartnerService : GenericService<Guid, Partner, PartnerDto>, IPartnerService
{
    public PartnerService(IGenericRepository<Guid, Partner> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}