using Actividad3.Domain.Entities;
using Actividad3.Domain.Enums;

namespace Actividad3.Presentation.Dtos;

#nullable disable
public class CatDto : IDto, IMapToEntity<Cat>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
    
    public Cat ToEntity()
    {
        return new Cat()
        {
            Id = Id,
            Name = Name,
            Age = Age,
            Race = Race,
            Weight = Weight,
            HealthState = HealthState,
            ColonyId = ColonyId,
        };
    }
}