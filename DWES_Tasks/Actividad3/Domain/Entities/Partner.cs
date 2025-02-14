namespace Actividad3.Domain.Entities;

#nullable disable
public class Partner : Entity<Guid>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }

    public virtual List<ColonyPartner> ColonyPartnerItems { get; set; } = [];
}