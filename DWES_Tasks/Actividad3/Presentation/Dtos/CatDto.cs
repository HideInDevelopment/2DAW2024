using Actividad3.Domain.Enums;

namespace Actividad3.Presentation.Dtos;

#nullable disable
public class CatDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public IDto Colony { get; set; }
}