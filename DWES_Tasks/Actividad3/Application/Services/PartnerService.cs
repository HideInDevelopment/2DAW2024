using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Services;

public class PartnerService : GenericService<Guid, Partner, PartnerDto>, IPartnerService
{
    public PartnerService(IGenericRepository<Guid, Partner> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}