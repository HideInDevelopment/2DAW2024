using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Application.Profiles;

public static class ColonyMapper
{
    public static IDto MapFromColonyToDto(Colony colony)
    {
        return new ColonyWithCatIdsDto()
        {
            Id = colony.Id,
            Name = colony.Name,
            Location = colony.Location,
            TelephoneNumber = colony.TelephoneNumber,
            MobileNumber = colony.MobileNumber,
            Description = colony.Description,
            Image = colony.Image
        };
    }
}