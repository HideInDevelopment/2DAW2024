using Actvidad3.Domain.Contracts;

namespace Actvidad3.Domain.Entities;

#nullable disable
public class ColonyPartner : IEntity
{
    public Guid Id { get; set; }
    
    public Guid ColonyId { get; set; }
    public Colony Colony { get; set; }

    public Guid PartnerId { get; set; }
    public Partner Partner { get; set; }
}