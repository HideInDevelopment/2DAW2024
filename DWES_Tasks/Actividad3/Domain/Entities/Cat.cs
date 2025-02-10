using Actividad3.Domain.Enums;

namespace Actividad3.Domain.Entities;

#nullable disable

public class Cat : Entity<Guid>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
    
    public virtual Colony Colony { get; set; }
}