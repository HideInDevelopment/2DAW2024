using Actividad3.Application.Settings;
using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class CatConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(150);
        builder.Property(g => g.Age).HasMaxLength(2);
        builder.Property(g => g.Race).HasMaxLength(50);
        builder.Property(g => g.Weight).HasMaxLength(5);
        builder.Property(g => g.HealthState);
        builder.Property(g => g.ColonyId);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Cat_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Cat_Name");
        builder.HasIndex(g => g.Race).HasDatabaseName("IX_Cat_Race");
        
        builder.ToTable("Cats", "DWES");
    }
}