using Actividad3.Application.Settings;
using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class CatConfiguration : IEntityConfiguration, IEntityTypeConfiguration<Cat>
{
    private readonly CatSettings _catSettings;

    public CatConfiguration(IOptions<AppSettings> appSettings)
    {
        _catSettings = appSettings.Value.Cat;
    }
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(_catSettings.NameMaxLength);
        builder.Property(g => g.Age).HasMaxLength(_catSettings.AgeMaxLength);
        builder.Property(g => g.Race).HasMaxLength(_catSettings.RaceMaxLength);
        builder.Property(g => g.Weight).HasMaxLength(_catSettings.WeightMaxLength);
        builder.Property(g => g.HealthState);
        builder.Property(g => g.ColonyId);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Cat_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Cat_Name");
        builder.HasIndex(g => g.Race).HasDatabaseName("IX_Cat_Race");
        
        builder.ToTable("Cats", "DWES");
    }
}