namespace Actividad3.Domain.Entities;

#nullable disable
public class ColonyPartner : Entity<Guid>   
{
    public Guid ColonyId { get; set; }
    public virtual Colony Colony { get; set; }

    public Guid PartnerId { get; set; }
    public virtual Partner Partner { get; set; }
}