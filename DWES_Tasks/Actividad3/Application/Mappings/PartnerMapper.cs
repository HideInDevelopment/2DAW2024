using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public class PartnerMapper
{
    public static Partner MapDtoToEntity<TDto>(TDto dto) where TDto : IDto, IMapToEntity<Partner>
    {
        return dto.ToEntity();
    }
    
    public static PartnerDto MapEntityToDto<TEntity>(TEntity entity) where TEntity : IMapToDto<PartnerDto>
    {
        return entity.ToDto();
    }
}