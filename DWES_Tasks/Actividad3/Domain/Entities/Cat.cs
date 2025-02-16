using Actividad3.Domain.Enums;
using Actividad3.Presentation.Dtos;

namespace Actividad3.Domain.Entities;

#nullable disable

public class Cat : Entity<Guid>,  IMapToDto<CatDto>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
    
    public virtual Colony Colony { get; set; }
    
    public CatDto ToDto()
    {
        return new CatDto()
        {
            Id = Id,
            Name = Name,
            Age = Age,
            Race = Race,
            Weight = Weight,
            HealthState = HealthState,
            ColonyId = ColonyId
        };
    }
}