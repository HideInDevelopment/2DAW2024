using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public static class ColonyMapper
{
    public static Colony MapDtoToEntity<TDto>(TDto dto) where TDto : IDto, IMapToEntity<Colony>
    {
        return dto.ToEntity();
    }
    
    public static ColonyDto MapEntityToDto<TEntity>(TEntity entity) where TEntity : IMapToDto<ColonyDto>
    {
        return entity.ToDto();
    }
}