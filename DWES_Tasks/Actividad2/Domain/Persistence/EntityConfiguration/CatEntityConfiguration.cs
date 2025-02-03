using Actividad2.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Actividad2.Domain.Persistence.EntityConfiguration;

public class CatEntityConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(75);
        builder.Property(g => g.Age);
        builder.Property(g => g.Race).HasMaxLength(50);
        builder.Property(g => g.Weight);
        builder.Property(g => g.HealthState);
        builder.Property(g => g.ColonyId);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Cat_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Cat_Name");
        builder.HasIndex(g => g.Race).HasDatabaseName("IX_Cat_Race");
        builder
            .HasIndex(g => new { g.Race, g.ColonyId })
            .HasDatabaseName("IX_Cat_Race_ColonyId");
        builder
            .HasIndex(g => new { g.Name, g.ColonyId })
            .HasDatabaseName("IX_Cat_Name_ColonyId");

        builder.ToTable("Cats", "DWES");
    }
}