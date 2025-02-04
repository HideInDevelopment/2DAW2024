using Actvidad3.Domain.Entities;
using Actvidad3.Presentation.Dtos;

namespace Actvidad3.Domain.Services;

public interface IPartnerService : IGenericService<Guid, PartnerDto, Partner>
{
    
}