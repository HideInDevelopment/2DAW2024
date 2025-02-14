using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public static class CatMapper
{
    public static IDto MapFromCatToDtoWithColonyId(Cat cat)
    {
        return new CatWithoutColonyItemDto()
        {
            Id = cat.Id,
            Name = cat.Name,
            Age = cat.Age,
            Race = cat.Race,
            Weight = cat.Weight,
            HealthState = cat.HealthState,
            ColonyId = cat.ColonyId
        };
    }

    public static IDto MapFromCatToDtoWithColony(Cat cat)
    {
        return new CatDto()
        {
            Id = cat.Id,
            Name = cat.Name,
            Age = cat.Age,
            Race = cat.Race,
            Weight = cat.Weight,
            HealthState = cat.HealthState,
            Colony = ColonyMapper.MapFromColonyToDto(cat.Colony),
        };
    }

    public static Cat MatFromCatDtoToCat(IDto dto)
    {
        if (dto is not CatDto catDto)
            return new Cat();
        
        return new Cat()
        {
            Id = catDto.Id,
            Name = catDto.Name,
            Age = catDto.Age,
            Race = catDto.Race,
            Weight = catDto.Weight,
            HealthState = catDto.HealthState,
            ColonyId = CheckIfColony(catDto.Colony).Id,
        };
    }

    private static Colony CheckIfColony(IDto dto)
    {
        return dto is not ColonyDto colonyDto 
            ? new Colony() 
            : ColonyMapper.MapFromDtoToSimpleColony(colonyDto);
    }
}