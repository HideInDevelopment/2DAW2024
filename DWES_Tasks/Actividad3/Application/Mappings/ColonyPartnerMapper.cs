using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public class ColonyPartnerMapper
{
    public static ColonyPartner MapDtoToEntity<TDto>(TDto dto) where TDto : IDto, IMapToEntity<ColonyPartner>
    {
        return dto.ToEntity();
    }

    public static ColonyPartnerDto MapEntityToDto<TEntity>(TEntity entity) where TEntity : IMapToDto<ColonyPartnerDto>
    {
        return entity.ToDto();
    }
}