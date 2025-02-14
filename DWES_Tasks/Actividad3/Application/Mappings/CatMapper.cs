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
            Colony = ColonyMapper.MapFromColonyToDtoWithCatIds(cat.Colony),
        };
    }
}