using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Domain.Services;

public interface IPartnerService : IGenericService<Guid, Partner, PartnerDto>
{
    
}