using Actividad2.Domain.Enum;

namespace Actividad2.Domain.Dto;
#nullable disable
public class CatDto
{
    public CatDto(){}
    public CatDto(Guid id, string name, int age, string race, int weight, HealthState healthState, Guid colonyId)
    {
        Id = id;
        Name = name;
        Age = age;
        Race = race;
        Weight = weight;
        HealthState = healthState;
        ColonyId = colonyId;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public int Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}