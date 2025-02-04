using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Services;

public class PartnerService : GenericService<Guid, PartnerDto, Partner>, IPartnerService
{
    public PartnerService(IGenericRepository<Guid, PartnerDto> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}