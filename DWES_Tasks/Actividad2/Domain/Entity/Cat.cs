using Actividad2.Domain.Enum;
using Actividad2.Domain.Generic.Model;

namespace Actividad2.Domain.Entity;

#nullable disable

public class Cat : Entity<Guid>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}