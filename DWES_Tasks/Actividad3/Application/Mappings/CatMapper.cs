using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public static class CatMapper
{
    public static Cat MapDtoToEntity<TDto>(TDto dto) where TDto : IDto, IMapToEntity<Cat>
    {
        return dto.ToEntity();
    }

    public static CatDto MapEntityToDto<TEntity>(TEntity entity) where TEntity : IMapToDto<CatDto>
    {
        return entity.ToDto();
    }
}