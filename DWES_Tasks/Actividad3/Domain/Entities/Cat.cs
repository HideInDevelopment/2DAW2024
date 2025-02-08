using Actvidad3.Domain.Contracts;
using Actvidad3.Domain.Enums;

namespace Actvidad3.Domain.Entities;

#nullable disable

public class Cat : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public double Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}