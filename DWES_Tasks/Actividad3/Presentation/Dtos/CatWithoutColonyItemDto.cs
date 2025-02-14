using Actividad3.Domain.Enums;

namespace Actividad3.Presentation.Dtos;

public class CatWithoutColonyItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}