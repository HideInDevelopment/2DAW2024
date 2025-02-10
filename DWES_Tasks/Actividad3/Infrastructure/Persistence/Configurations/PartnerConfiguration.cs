using Actividad3.Application.Settings;
using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class PartnerConfiguration : IEntityConfiguration, IEntityTypeConfiguration<Partner>
{
    private readonly PartnerSettings _partnerSettings;

    public PartnerConfiguration(IOptions<AppSettings> appSettings)
    {
        _partnerSettings = appSettings.Value.Partner;
    }
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(_partnerSettings.NameMaxLength);
        builder.Property(g => g.Age).HasMaxLength(_partnerSettings.AgeMaxLength);
        builder.Property(g => g.TelephoneNumber).HasMaxLength(_partnerSettings.TelephoneNumberMaxLength);
        builder.Property(g => g.Email).HasMaxLength(_partnerSettings.EmailMaxLength);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Partner_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Partner_Name");
        
        builder.HasMany(p => p.ColonyPartnerItems)
               .WithOne(cp => cp.Partner)
               .HasForeignKey(cp => cp.PartnerId);
        
        builder.ToTable("Partners", "DWES");
    }
}