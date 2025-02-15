namespace Actividad3.Domain.Entities;

#nullable disable
public class Colony : Entity<Guid>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public virtual List<Cat> CatItems { get; set; } = [];
    
    public virtual List<ColonyPartner> ColonyPartnerItems { get; set; } = [];
}