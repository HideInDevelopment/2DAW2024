namespace Actividad3.Presentation.Dtos;

public interface IMapToDto<TDto> where TDto : class
{
    TDto ToDto();
}