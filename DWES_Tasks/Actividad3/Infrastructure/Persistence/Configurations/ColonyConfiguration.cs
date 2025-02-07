using Actvidad3.Application.Settings;
using Actvidad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Actvidad3.Infrastructure.Persistence.Configurations;

public class ColonyConfiguration : IEntityConfiguration, IEntityTypeConfiguration<Colony>
{
    private readonly ColonySettings _colonySettings;

    public ColonyConfiguration(IOptions<AppSettings> appSettings)
    {
        _colonySettings = appSettings.Value.Colony;
    }
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<Colony> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(_colonySettings.NameMaxLength);
        builder.Property(g => g.Location).HasMaxLength(_colonySettings.LocationMaxLength);
        builder.Property(g => g.TelephoneNumber).HasMaxLength(_colonySettings.TelephoneNumberMaxLength);
        builder.Property(g => g.MobileNumber).HasMaxLength(_colonySettings.MobileNumberMaxLength);
        builder.Property(g => g.Description).HasMaxLength(_colonySettings.DescriptionMaxLength);
        builder.Property(g => g.Image).HasMaxLength(_colonySettings.ImageMaxLength);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Colony_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Colony_Name");
        
        builder.HasMany<Cat>().WithOne().HasForeignKey("Id");
        builder.HasMany(c => c.ColonyPartnerItems)
               .WithOne(cp => cp.Colony)
               .HasForeignKey(cp => cp.ColonyId);
    }
}